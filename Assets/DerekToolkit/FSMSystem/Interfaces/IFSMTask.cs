using DerekToolkit.FSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Interfaces
{
    public interface IFSMTask
    {
        public void InitTask(GameObject actor);
        public void OnTaskStart();
        public FSMTaskStatus OnTaskUpdate();
        public FSMTaskStatus OnTaskFixedUpdate();
        public void OnTaskFinish();
    }
}
