using System;
using DerekToolkit.FSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Base
{
    public enum FSMTaskStatus
    {
        Sleep,
        Run,
        Stop,
        Completed,
        Failed
    }
    
    public class FSMBaseTask : ScriptableObject, IFSMTask
    {
        protected FSMTaskStatus m_FSMTaskStatus; 
            
        public virtual void InitTask(GameObject actor)
        {
            m_FSMTaskStatus = FSMTaskStatus.Sleep;
        }

        public virtual void OnTaskStart()
        {
            m_FSMTaskStatus = FSMTaskStatus.Run;
        }
        
        public virtual FSMTaskStatus OnTaskUpdate()
        {
            return m_FSMTaskStatus;
        }
        
        public virtual FSMTaskStatus OnTaskFixedUpdate()
        {
            return m_FSMTaskStatus;
        }
        
        public virtual void OnTaskFinish()
        {
            
        }
    }
}
