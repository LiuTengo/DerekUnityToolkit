using UnityEngine;

namespace DerekToolkit.HFSMSystem.Base
{
    //[CreateAssetMenu(menuName = "DerekToolkit/HFSM/Conditions/HFSMBaseCondition",fileName = "HFSMBaseCondition")]
    public class HFSMBaseCondition : ScriptableObject
    {
        public virtual void InitConditions(GameObject actor)
        { }
        
        public virtual bool IsFitCondition()
        {
            return true;
        }
    }
}