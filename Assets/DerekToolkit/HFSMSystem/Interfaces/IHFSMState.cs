
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Interfaces
{
    public interface IHFSMState
    {
        public void InitState(GameObject owner,HFSMController hfsmController);
        public void OnEnterState();
        public void OnUpdateState();
        public void OnFixedUpdateState();
        public void OnExitState();
        public bool OnExitRequest();

        public string GetCurrentStateName();
    }
}
