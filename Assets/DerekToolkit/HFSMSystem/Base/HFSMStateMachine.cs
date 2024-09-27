using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Base
{
    [CreateAssetMenu(menuName = "DerekToolkit/HFSM/State/HFSMStateMachine",fileName = "HFSMStateMachine")]
    public class HFSMStateMachine : HFSMStateBase
    {
        /// <summary>
        /// 默认进入的状态
        /// </summary>
        public HFSMStateBase defaultEnterState;
        /// <summary>
        /// 子状态节点
        /// </summary>
        public List<HFSMState> childStates;
        /// <summary>
        /// 子状态机
        /// </summary>
        public List<HFSMStateMachine> childStateMachines;
        
        private HFSMStateBase m_CurrentState;
        
        private readonly Dictionary<string, HFSMState> m_States = new Dictionary<string, HFSMState>();
        private readonly Dictionary<string, HFSMStateMachine> m_StateMachines = new Dictionary<string, HFSMStateMachine>();
        
        public override void InitState(GameObject owner,HFSMController hfsmController)
        {
            foreach (var state in childStates)
            {
                if (state)
                {
                    state.InitState(owner,hfsmController);
                    m_States.Add(state.stateName,state);
                }
            }
            foreach (var stateMachine in childStateMachines)
            {
                if (stateMachine)
                {
                    stateMachine.InitState(owner,hfsmController);
                    m_StateMachines.Add(stateMachine.stateName,stateMachine);
                }
            }
        }
        
        /// <summary>
        /// 进入某状态时调用
        /// </summary>
        /// <param name="targetState">目标状态</param>
        /// <param name="stateRecord">状态栈</param>
        /// <param name="bUseDefaultState">是否使用状态机默认状态</param>
        public void EnterState(HFSMStateBase targetState,ref Stack<HFSMStateBase> stateRecord,bool bUseDefaultState = false)
        {
            if (targetState == null && !bUseDefaultState)
            {
                return;
            }

            if (targetState == null && bUseDefaultState)
            {
                targetState = defaultEnterState;
            }

            if (targetState is HFSMState state)
            {
                //只有当没有子状态时（即已到叶节点）才检测是否默认状态
                if (m_StateMachines.Count == 0 && bUseDefaultState)
                {
                    m_CurrentState = defaultEnterState;
                    stateRecord.Push(m_CurrentState);
                    m_CurrentState.OnEnterState();
                    return;
                }
                //对于非叶子节点，优先查找子状态中有无目标状态，没有则查找子状态机是否有目标状态
                else
                {
                    if (m_States.ContainsValue(state))
                    {
                        m_CurrentState = state;
                        stateRecord.Push(m_CurrentState);
                        m_CurrentState.OnEnterState();
                        return;
                    }

                    var sm = GetChildStateMachine(state);
                    if (sm != null)
                    {
                        m_CurrentState = sm;
                        m_CurrentState.OnEnterState();
                        stateRecord.Push(m_CurrentState);
                        sm.EnterState(state, ref stateRecord, bUseDefaultState);
                        return;
                    }
                    else
                    {
                        Debug.LogError($"{stateName}中未找到任何包含目标节点（{state.stateName}）的子状态机" +
                                       $"{stateName} didn't find any state machine which contains {state.stateName}");
                        return;
                    }
                }
            }
            else if(targetState is HFSMStateMachine stateMachine)
            {
                //当前状态机中含有目标状态机器
                if (m_StateMachines.ContainsValue(stateMachine))
                {
                    //进入目标状态机，并进入目标状态机的默认状态
                    m_CurrentState = stateMachine;
                    stateRecord.Push(m_CurrentState);
                    stateMachine.EnterState(null,ref stateRecord,true);
                }
                //查找子状态机
                else
                {
                    var sm = GetChildStateMachine(stateMachine);
                    if (sm != null)
                    {
                        m_CurrentState = sm;
                        stateRecord.Push(m_CurrentState);
                        sm.EnterState(null,ref stateRecord,true);
                        return;
                    }
                    else
                    {
                        Debug.LogError($"{stateName}中未找到任何包含目标节点（{stateMachine.stateName}）的子状态机" +
                                       $"{stateName} didn't find any state machine which contains {stateMachine.stateName}");
                        return;
                    }
                }
            }
        }
        
        public override void OnEnterState()
        {
            if (m_CurrentState)
            {
                m_CurrentState.OnEnterState();
            }
        }

        public override void OnUpdateState()
        {
            if (m_CurrentState)
            {
                m_CurrentState.OnUpdateState();
            }
        }

        public override void OnFixedUpdateState()
        {
            if (m_CurrentState)
            {
                m_CurrentState.OnFixedUpdateState();
            }
        }

        public override void OnExitState()
        {
            if (m_CurrentState)
            {
                m_CurrentState.OnExitState();
                m_CurrentState = null;
            }
        }

        public override bool OnExitRequest()
        {
            if (m_CurrentState != null)
            {
                return m_CurrentState.OnExitRequest();
            }

            return true;
        }
        
        public override string GetCurrentStateName()
        {
            if (m_CurrentState == null)
            {
                return "Failed,CurrentState is Null!";
            }

            return $"StateMachine_{stateName}" + ". \n" + m_CurrentState.GetCurrentStateName();
        }

        public HFSMStateMachine FindAncestorStateMachine(HFSMState start,HFSMState target)
        {
            if (m_States.ContainsValue(start) && m_States.ContainsValue(target))
            {
                return this;
            }
            
            HFSMStateMachine startSM = null;
            HFSMStateMachine targetSM = null;
            foreach (var s in m_StateMachines)
            {
                startSM = s.Value.FindAncestorStateMachine(start,target);
                if (startSM != null) 
                {
                    break;
                }
            }
            foreach (var s in m_StateMachines)
            {
                targetSM = s.Value.FindAncestorStateMachine(start,target);
                if (targetSM != null) 
                {
                    break;
                }
            }

            if (startSM != null && targetSM != null)
            {
                return this;
            }

            if (startSM != null && targetSM == null)
            {
                return startSM;
            }

            if (startSM == null && targetSM != null)
            {
                return targetSM;
            }

            return null;
        }
        
        /// <summary>
        /// 检查该状态机有无目标状态
        /// </summary>
        /// <param name="target">目标状态机</param>
        /// <returns></returns>
        public bool ContainState(HFSMStateBase target)
        {
            if (m_States.ContainsKey(target.stateName) || m_StateMachines.ContainsKey(target.stateName))
            {
                return true;
            }
            
            foreach (var sm in m_StateMachines)
            {
                if (sm.Value.ContainState(target))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ContainStateMachine(HFSMStateMachine stateMachine)
        {
            if (m_StateMachines.ContainsKey(stateMachine.stateName))
            {
                return true;
            }
            
            foreach (var sm in m_StateMachines)
            {
                if (sm.Value.ContainStateMachine(stateMachine))
                {
                    return true;
                }
            }
            return false;
        }
        
        /// <summary>
        /// 获取含有目标状态的子状态机
        /// </summary>
        /// <param name="target">目标状态</param>
        /// <returns></returns>
        private HFSMStateMachine GetChildStateMachine(HFSMState target)
        {
            foreach (var sm in m_StateMachines)
            {
                if (sm.Value.ContainState(target))
                {
                    return sm.Value;
                }
            }
            return null;
        }
        
        private HFSMStateMachine GetChildStateMachine(HFSMStateMachine stateMachine)
        {
            foreach (var sm in m_StateMachines)
            {
                if (sm.Value.ContainStateMachine(stateMachine))
                {
                    return sm.Value;
                }
            }
            return null;
        }
    }
}