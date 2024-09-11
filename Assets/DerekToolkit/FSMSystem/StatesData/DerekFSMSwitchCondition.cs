using UnityEngine;

namespace DerekToolkit.FSMSystem
{
    /// <summary>
    /// 状态切换条件
    /// </summary>
    public class DerekFSMSwitchCondition : ScriptableObject
    {
        public virtual bool FitCondition()
        {
            return true;
        }
    }
}