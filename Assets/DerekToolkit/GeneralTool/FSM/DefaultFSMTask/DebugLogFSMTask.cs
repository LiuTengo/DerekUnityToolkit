using DerekToolkit.GeneralTool.FSM.Base.Task;
using Unity.VisualScripting;
using UnityEngine;

namespace DerekToolkit.GeneralTool.FSM.DefaultFSMTask
{
    public class DebugLogFSMTask : UFSMTask
    {
        private string logInfo;
        
        public DebugLogFSMTask(string info)
        {
            logInfo = info;
        }

        public override void OnEnterState()
        {
            Debug.Log("Start Debugging");
        }

        public override void OnFixedUpdate()
        {
            Debug.Log(logInfo);
        }

        public override void OnExitState()
        {
            Debug.Log("Finish Debugging");
        }
    }
}