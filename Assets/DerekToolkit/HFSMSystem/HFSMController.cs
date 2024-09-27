using System;
using System.Collections.Generic;
using System.Linq;
using DerekToolkit.HFSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.HFSMSystem
{
    [Serializable]
    public class HFSMDebugSetting
    {
        public Color fontColor = Color.green;
        public int fontSize = 25;
        public Rect rect;
    }
    
    public class HFSMController : MonoBehaviour
    {
        [SerializeField] private HFSMStateMachine stateMachine;

        public Stack<HFSMStateBase> m_RunningStates = new Stack<HFSMStateBase>();
        public HFSMStateBase m_PeekState;
#if UNITY_EDITOR
        [Header("调试设置  DebugSetting")]
        [SerializeField]private HFSMDebugSetting debugSetting;
#endif
        // Start is called before the first frame update
        private void Start()
        {
            stateMachine.InitState(gameObject,this);
            m_RunningStates.Push(stateMachine);
            stateMachine.EnterState(null,ref m_RunningStates,true);
            m_PeekState = m_RunningStates.Peek();
        }

        // Update is called once per frame
        private void Update()
        {
            m_PeekState.OnUpdateState();
        }

        private void FixedUpdate()
        {
            m_PeekState.OnFixedUpdateState();
        }

        public void SwitchState(HFSMState startState, HFSMStateBase targetState)
        {
            if (startState.stateName == targetState.stateName) return;
            //栈弹出直到找到共同祖先状态机
            var sPeek = m_RunningStates.Pop(); //弹出栈顶状态节点
            sPeek.OnExitState();
            var sm = (HFSMStateMachine)m_RunningStates.Peek();
            while (sm != null && !sm.ContainState(targetState))
            {
                sPeek = m_RunningStates.Pop();
                sPeek.OnExitState();
                sm = (HFSMStateMachine)m_RunningStates.Peek();
            }

            if (m_RunningStates.Count>0)
            {
                sm = (HFSMStateMachine)m_RunningStates.Peek();
            }
            //从祖先状态机进入到目标状态
            sm.EnterState(targetState,ref m_RunningStates);
            //更新运行状态
            m_PeekState = m_RunningStates.Peek();
        }

        private HFSMStateMachine FindAncestorStateMachine(HFSMState target,Stack<HFSMStateBase> copyRunningStates)
        {
            copyRunningStates.Pop(); //弹出栈顶状态节点
            var sm = (HFSMStateMachine)copyRunningStates.Peek();
            while (sm != null && !sm.ContainState(target))
            {
                copyRunningStates.Pop();
                sm = (HFSMStateMachine)copyRunningStates.Peek();
            }

            return sm;
        }
        
#if UNITY_EDITOR
        private void OnGUI()
        {
            string stateName = stateMachine.GetCurrentStateName();
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = debugSetting.fontSize;
            labelStyle.normal.textColor = debugSetting.fontColor;
            
            GUI.Label(debugSetting.rect,"HFSM: \n"+stateName,labelStyle);
        }
#endif
    }
}