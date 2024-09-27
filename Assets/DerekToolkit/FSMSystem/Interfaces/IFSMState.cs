using DerekToolkit.FSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Interfaces
{
    public interface IFSMState
    {
        public void InitState(FSMRootState controller,GameObject actor);
        public void OnEnterState();
        public void OnUpdateState();
        public void OnFixedUpdateState();
        public void OnExitState();
    }
}
