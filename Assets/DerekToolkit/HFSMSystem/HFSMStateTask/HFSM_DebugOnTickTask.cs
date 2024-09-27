using DerekToolkit.HFSMSystem.Base;
using DerekToolkit.HFSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.HFSMStateTask
{
    [CreateAssetMenu(menuName = "DerekToolkit/HFSM/Tasks/HFSM_DebugOnTickTask",fileName = "HFSM_DebugOnTickTask")]
    public class HFSM_DebugOnTickTask : HFSMBaseTask
    {
        public float Duration;
        public string DebugInfo;

        private float tick = 0.0f;

        public override void OnTaskStart()
        {
            base.OnTaskStart();
            tick = 0.0f;
        }

        public override HFSMTaskStatus OnTaskUpdate()
        {
            if (tick<Duration)
            {
                tick += Time.deltaTime;
                Debug.Log(DebugInfo);
            }
            else
            {
                HfsmTaskStatus = HFSMTaskStatus.Completed;
                checkTransitionOnComplete?.Invoke();
            }
            return HfsmTaskStatus;
        }
    }
}