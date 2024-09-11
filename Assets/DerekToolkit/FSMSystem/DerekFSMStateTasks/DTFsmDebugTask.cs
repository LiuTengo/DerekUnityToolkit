using DerekToolkit.FSMSystem;
using UnityEngine;

namespace DerekToolkit.FSMSystem
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/StateTask/DTFsmDebugTask" , fileName = "DT_FsmDebugTask")]
    public class DTFsmDebugTask : DerekFSMStateTask
    {
        public string debugInfo;
        
        public override void OnTaskUpdate()
        {
            Debug.Log(debugInfo);
        }
    }
}