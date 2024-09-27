using DerekToolkit.HFSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Interfaces
{
    public interface IHFSMTransition
    {
        public void InitTransition(HFSMState state, HFSMController controller, GameObject actor);

        public void CheckWhetherShouldTransition();
    }
}