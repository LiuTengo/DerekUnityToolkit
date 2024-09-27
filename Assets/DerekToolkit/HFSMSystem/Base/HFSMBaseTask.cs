using System;
using DerekToolkit.GeneralTool.EventCenter;
using DerekToolkit.HFSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Base
{
    public class HFSMBaseTask : ScriptableObject, IHFSMTask
    {
        protected HFSMTaskStatus HfsmTaskStatus;

        protected Action checkTransitionOnComplete;
        protected Action checkTransitionOnFailed;
        protected Action checkTransitionOnTick;

        public void AddSwitchRequest(HFSMTransition transition)
        {
            switch (transition.Trigger)
            {
                case HFSMTransitionMode.OnTick:
                    checkTransitionOnTick += transition.CheckWhetherShouldTransition;
                    break;
                case HFSMTransitionMode.OnStateCompleted:
                    checkTransitionOnComplete += transition.CheckWhetherShouldTransition;
                    break;
                case HFSMTransitionMode.OnStateFailed:
                    checkTransitionOnFailed += transition.CheckWhetherShouldTransition;
                    break;
                case HFSMTransitionMode.OnEvent:
                    EventCenter.instance.RegisterEvent(transition.TransitionName,transition.CheckWhetherShouldTransition);
                    break;
            }
        }
        
        public void RemoveAllSwitchRequest()
        {
            checkTransitionOnComplete = null;
            checkTransitionOnFailed = null;
            checkTransitionOnTick = null;
        }
        
        public virtual void InitTask(GameObject actor)
        {
            HfsmTaskStatus = HFSMTaskStatus.Sleep;
        }

        public virtual void OnTaskStart()
        {
            HfsmTaskStatus = HFSMTaskStatus.Run;
        }

        public virtual HFSMTaskStatus OnTaskUpdate()
        {
            return HfsmTaskStatus;
        }

        public virtual HFSMTaskStatus OnTaskFixedUpdate()
        {
            return HfsmTaskStatus;
        }

        public virtual void OnTaskFinish()
        {
            HfsmTaskStatus = HFSMTaskStatus.Sleep;
        }
    }
}