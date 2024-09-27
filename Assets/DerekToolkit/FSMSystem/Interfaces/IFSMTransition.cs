using DerekToolkit.FSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Interfaces
{
    public interface IFSMTransition
    {
        public void InitTransition(FSMBaseState state, GameObject actor);

        public void CheckWhetherShouldTransition();
    }
}