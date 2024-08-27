using System;
using System.Collections.Generic;
using UnityEngine;

namespace DerekToolkit.GeneralTool.FSM
{
    public class UFSMController
    {
        private readonly Dictionary<string,UFSMState> m_States;
        private UFSMState m_CurrentState;

        //FSMController的构造函数
        public UFSMController()
        {
            this.m_States = new Dictionary<string, UFSMState>();
        }

        //添加状态
        public void AddState(string type, UFSMState state)
        {
            //若已经包含该状态，则返回
            if (m_States.ContainsKey(type))
                return;
            //未包含该状态，则添加一个新状态
            m_States.Add(type,state);
        }

        //删除状态
        public void DeletState(string type,UFSMState state)
        {
            //若未包含需删除的状态，则返回
            if (!m_States.ContainsKey(type))
                return;
            //包含删除的状态，则删除该状态
            m_States.Remove(type);
        }

        //切换状态
        public void SwitchState(string type)
        {
            if (!m_States.ContainsKey(type))
                return;

            if (m_CurrentState != null)
                m_CurrentState.ExitState();

            m_CurrentState = m_States[type];
            m_CurrentState.EnterState();
        }

        //更新状态
        public void Update()
        {
            m_CurrentState?.UpdateState();
        }

        public void FixedUpdate()
        {
            m_CurrentState?.FiexedUpdate();
        }

        public void LateUpdate()
        {
            m_CurrentState?.LateUpdate();
        }
    }
}
