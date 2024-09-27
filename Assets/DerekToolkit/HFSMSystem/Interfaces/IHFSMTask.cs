using DerekToolkit.FSMSystem.Base;
using DerekToolkit.HFSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Interfaces
{
    public enum HFSMTaskStatus
    {
        Sleep,
        Run,
        Stop,
        Completed,
        Failed
    }
    
    public interface IHFSMTask
    {
        public void InitTask(GameObject actor);
        public void OnTaskStart();
        public HFSMTaskStatus OnTaskUpdate();
        public HFSMTaskStatus OnTaskFixedUpdate();
        public void OnTaskFinish();
    }
}