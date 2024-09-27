using UnityEngine;

namespace DerekToolkit.FSMSystem.Base
{
    public class FSMBaseCondition : ScriptableObject
    {
        public virtual void InitConditions(FSMBaseState state, GameObject actor)
        { }
        
        public virtual bool IsFitCondition()
        {
            return true;
        }
    }
}
