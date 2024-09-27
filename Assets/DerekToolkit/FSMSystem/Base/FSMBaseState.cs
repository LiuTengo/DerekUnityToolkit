using System;
using DerekToolkit.FSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Base
{
    [Serializable]
    public class FSMBaseState :IFSMState
    {
        public string stateName;
        public FSMBaseCondition[] enterConditions;
        public FSMBaseTask task;
        public FSMTransition[] transitions;
        
        public Action onTaskRun;
        public Action onTaskCompleted;
        public Action onTaskFailed;
        
        protected FSMRootState m_FsmRoot;

        public virtual void InitState(FSMRootState controller, GameObject actor)
        {
            m_FsmRoot = controller;

            if (task)
            {
                task.InitTask(actor);
            }

            foreach (var c in enterConditions)
            {
                c.InitConditions(this,actor);
            }
            
            foreach (var t in transitions)
            {
                t.InitTransition(this,actor);
            }
        }

        public virtual void OnEnterState()
        {
            if (task)
            { 
                task.OnTaskStart(); 
            }
            //TODO：修改为HFSM
            //else
            // {
            //     //检查Transitions，有符合条件的则进入那个状态
            //     
            //     //没有则检查子状态树的进入条件，有则进入那个状态
            //     
            //     //没有则返回null
            // }
        }
            
        public virtual void OnUpdateState()
        {
            if (task)
            {
                FSMTaskStatus status = task.OnTaskUpdate();
                switch (status)
                {
                    case FSMTaskStatus.Run:
                        onTaskRun?.Invoke();
                        break;
                    case FSMTaskStatus.Completed:
                        onTaskCompleted?.Invoke();
                        break;
                    case FSMTaskStatus.Failed:
                        onTaskFailed?.Invoke();
                        break;
                }
            }
        }
        
        public virtual void OnFixedUpdateState()
        {
            if (task)
            {
                task.OnTaskFixedUpdate();
            }
        }
        
        public virtual void OnExitState()
        {
            if (task)
            {
                task.OnTaskFinish();
            }
        }

        public virtual bool CanEnterState()
        {
            if (enterConditions.Length<=0)
            {
                return true;
            }

            foreach (var c in enterConditions)
            {
                if (c.IsFitCondition()) continue;
                return false;
            }
            return true;
        }

        public void SwitchState(string name)
        {
            m_FsmRoot.SwitchState(name);
        }
    }
}
