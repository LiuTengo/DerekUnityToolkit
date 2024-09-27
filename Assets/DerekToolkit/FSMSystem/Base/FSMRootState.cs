using System.Collections.Generic;
using DerekToolkit.FSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Base
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/States/FSM_RootState", fileName = "FSMRootState")]
    public class FSMRootState : ScriptableObject,IFSMState
    {
        [SerializeField]private FSMBaseState[] fsmBaseStates;

        private Dictionary<string,FSMBaseState> m_StatesSet = new();
        private FSMBaseState m_CurrentState;

        public void InitState(FSMRootState controller,GameObject actor)
        {
            foreach (var s in fsmBaseStates)
            {
                s.InitState(this, actor);

                m_StatesSet.Add(s.stateName, s);
            }
        }

        public void OnEnterState()
        {
            foreach (var s in fsmBaseStates)
            {
                if (s.CanEnterState())
                {
                    s.OnEnterState();
                    m_CurrentState = s;
                    return;
                }
            }
            m_CurrentState = null;
        }

        public void OnUpdateState()
        {
            m_CurrentState.OnUpdateState();
        }

        public void OnFixedUpdateState()
        {
            m_CurrentState.OnFixedUpdateState();
        }

        public void SwitchState(string stateName)
        {
            if(stateName == null)
                Debug.LogError($"CurrentState{m_CurrentState.stateName}: transition destination is null");

            if (m_StatesSet.ContainsKey(stateName))
            {
                m_CurrentState.OnExitState();
                m_CurrentState = m_StatesSet[stateName];
                m_CurrentState.OnEnterState();
            }
            else
            {
                Debug.LogError($"Didn't find any state called {stateName}");
            }
        }

        public string GetCurrentStateName()
        {
            return m_CurrentState != null ? m_CurrentState.stateName : "Failed";
        }

        public void OnExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}
