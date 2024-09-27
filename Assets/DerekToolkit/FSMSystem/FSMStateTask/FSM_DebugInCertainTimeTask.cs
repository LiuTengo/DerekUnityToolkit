using DerekToolkit.FSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.FSMSystem.FSMStateTask
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/Tasks/FSM_DebugInCertainTimeTask",fileName = "FSM_DebugInCertainTimeTask")]
    public class FSM_DebugInCertainTimeTask : FSMBaseTask
    {
        public string debugInfo;
        public float duration;

        private float tick = 0.0f;
        public override void OnTaskStart()
        {
            base.OnTaskStart();

            tick = 0.0f;
        }

        public override FSMTaskStatus OnTaskUpdate()
        {
            if (tick < duration)
            {
                Debug.Log($"DebugTask:{debugInfo}");
                tick += Time.deltaTime;
                
                return FSMTaskStatus.Run;
            }
            else
            {
                return FSMTaskStatus.Completed;
            }
        }
    }
}
