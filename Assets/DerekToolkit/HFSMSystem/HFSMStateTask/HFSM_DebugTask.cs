using DerekToolkit.HFSMSystem.Base;
using DerekToolkit.HFSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.HFSMStateTask
{
    [CreateAssetMenu(menuName = "DerekToolkit/HFSM/Tasks/HFSM_DebugTask",fileName = "HFSM_DebugTask")]
    public class HFSM_DebugTask : HFSMBaseTask
    {
        public string DebugInfo;

        public override HFSMTaskStatus OnTaskUpdate()
        {
            Debug.Log(DebugInfo);
            checkTransitionOnTick?.Invoke();
            return HfsmTaskStatus;
        }
    }
}