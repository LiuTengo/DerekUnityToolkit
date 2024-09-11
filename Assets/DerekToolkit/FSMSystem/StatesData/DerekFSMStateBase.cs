using System;
using DerekToolkit.FSMSystem;
using UnityEngine;

namespace DerekToolkit.FSMSystem
{
    
    /// <summary>
    ///  状态切换信息
    /// </summary>
    [Serializable]
    public class DerekFSMTransition
    {
        public string destinationName;
        public DerekFSMSwitchCondition[] exitConditions;

        public bool ShouldSwitchState()
        {
            if (exitConditions.Length <= 0) return true;
            
            foreach (var t in exitConditions)
            {
                if (t.FitCondition()) continue;
                
                return false;
            }

            return true;
        }

        public string GetTransitionInfo()
        {
            return destinationName;
        }
    }

    /// <summary>
    /// 一个基础的FSM状态,更新Task任务
    /// </summary>
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/StateSO" , fileName = "DerekFSM_StateSO")][Serializable]
    public class DerekFSMStateBase : ScriptableObject
    {
        public string stateName = "DerekFSM_BaseStateSO";
        public DerekFSMSwitchCondition[] enterConditions;
        public DerekFSMStateBase[] childStates;
        public DerekFSMStateTask stateTask;
        public DerekFSMTransition[] transition;

        protected FSMTree StateController;
        public void InitState(FSMTree fsmTree)
        {
            fsmTree.AddState(stateName,this);
            StateController = fsmTree;
            
            foreach (var s in childStates)
            {
                s.InitState(fsmTree);
            }
        }
        
        public bool CanEnterState()
        {
            if (enterConditions.Length <= 0) return true;
            
            foreach (var t in enterConditions)
            {
                if (t.FitCondition()) continue;
                
                return false;
            }

            return true;
        }
        
        public void OnEnterState()
        {
            if(stateTask) stateTask.OnTaskBegin();
        }

        public void OnUpdateState()
        {
            if (transition.Length > 0)
            {
                foreach (var t in transition)
                {
                    if(t.ShouldSwitchState())
                    {
                        StateController.SwitchState(t.GetTransitionInfo());
                        break;
                    }
                }
            }
            else
            {
                foreach (var cs in childStates)
                {
                    if (cs.CanEnterState())
                    {
                        StateController.SwitchState(cs.stateName);
                        break;
                    }
                }
            }
            
            if(stateTask) stateTask.OnTaskUpdate();
        }
        
        public void OnFixedUpdateState()
        {
            if(stateTask) stateTask.OnTaskFixedUpdate();
        }

        public void OnExitState()
        { 
            if(stateTask) stateTask.OnTaskFinish();
        }
    }
}