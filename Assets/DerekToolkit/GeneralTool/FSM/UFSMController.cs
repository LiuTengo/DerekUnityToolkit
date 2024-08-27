using System;
using System.Collections.Generic;
using UnityEngine;

namespace DerekToolkit.GeneralTool.FSM
{
    public class UFSMController
    {
        private readonly Dictionary<string,UFSMState> m_States;
        private UFSMState m_CurrentState;

        //FSMController�Ĺ��캯��
        public UFSMController()
        {
            this.m_States = new Dictionary<string, UFSMState>();
        }

        //���״̬
        public void AddState(string type, UFSMState state)
        {
            //���Ѿ�������״̬���򷵻�
            if (m_States.ContainsKey(type))
                return;
            //δ������״̬�������һ����״̬
            m_States.Add(type,state);
        }

        //ɾ��״̬
        public void DeletState(string type,UFSMState state)
        {
            //��δ������ɾ����״̬���򷵻�
            if (!m_States.ContainsKey(type))
                return;
            //����ɾ����״̬����ɾ����״̬
            m_States.Remove(type);
        }

        //�л�״̬
        public void SwitchState(string type)
        {
            if (!m_States.ContainsKey(type))
                return;

            if (m_CurrentState != null)
                m_CurrentState.ExitState();

            m_CurrentState = m_States[type];
            m_CurrentState.EnterState();
        }

        //����״̬
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
