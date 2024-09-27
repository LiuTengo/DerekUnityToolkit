using DerekToolkit.FSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.FSMSystem.FSMStateTask
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/Tasks/FSM_DebugTask",fileName = "FSM_DebugTask")]
    public class FSM_DebugTask : FSMBaseTask
    {
        public string debugInfo;
        public override FSMTaskStatus OnTaskUpdate()
        {
            base.OnTaskUpdate();
            Debug.Log($"DebugTask:{debugInfo}");

            return FSMTaskStatus.Run;
        }
    }
}