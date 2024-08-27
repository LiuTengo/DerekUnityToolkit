using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using UnityEngine;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base.DefaultBehavioursTreesTask
{
    public class DebugLogTask : UBehaviourTreesTask
    {
        private string m_LOGInfo;

        public DebugLogTask(string logInfo)
        {
            m_LOGInfo = logInfo;
        }
        
        public override EBehaviourProcessState OnUpdate()
        {
            Debug.Log(m_LOGInfo);
            return EBehaviourProcessState.Success;
        }
    }
}