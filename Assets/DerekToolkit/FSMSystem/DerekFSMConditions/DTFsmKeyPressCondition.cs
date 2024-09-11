using DerekToolkit.FSMSystem;
using UnityEngine;

namespace DerekToolkit.FSMSystem
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/Conditions/KeyPressCondition" , fileName = "DT_FsmKeyPressCondition")]
    public class DTFsmKeyPressCondition : DerekFSMSwitchCondition
    {
        public KeyCode key;

        public override bool FitCondition()
        {
            return Input.GetKeyDown(key);
        }
    }
}