using UnityEngine;
using UnityEngine.Animations;

namespace DerekToolkit.GeneralTool
{
    public class StateBase : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex,
            AnimatorControllerPlayable controller)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex, controller);
            Debug.Log("EnterState");
        }
    }
}