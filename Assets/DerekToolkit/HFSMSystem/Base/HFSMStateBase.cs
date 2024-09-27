using System;
using DerekToolkit.HFSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Base
{
    [Serializable]
    public class StateData
    {
        public string StateName;
    }
    
    [Serializable]
    public class HFSMStateBase : ScriptableObject,IHFSMState
    {
        [SerializeField]protected StateData m_StateData;
        private HFSMStateBase m_ParentState;

        public string stateName => m_StateData.StateName;
        public HFSMStateBase parentState
        {
            set => m_ParentState = value;
            get => m_ParentState;
        }
        public virtual void InitState(GameObject owner,HFSMController hfsmController) { }
        public virtual void OnEnterState() { }

        public virtual void OnUpdateState() { }

        public virtual void OnFixedUpdateState() { }

        public virtual void OnExitState() { }

        public virtual bool OnExitRequest() {return true;}

        public virtual string GetCurrentStateName()
        {
            return null;
        }
    }
}