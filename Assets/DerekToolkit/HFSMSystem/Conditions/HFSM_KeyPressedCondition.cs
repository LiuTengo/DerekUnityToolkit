using DerekToolkit.HFSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Conditions
{
    [CreateAssetMenu(menuName = "DerekToolkit/HFSM/Conditions/HFSM_KeyPressedCondition",fileName = "HFSM_KeyPressedCondition")]
    public class HFSM_KeyPressedCondition : HFSMBaseCondition
    {
        public KeyCode keyCode;
        public override bool IsFitCondition()
        {
            if (Input.GetKeyDown(keyCode))
            {
                return true;
            }

            return false;
        }
    }
}