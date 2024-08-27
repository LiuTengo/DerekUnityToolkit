using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Interfaces;
using UnityEngine;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base.DefaultBehavioursTreesTask
{
    public class UBehaviourTreesMonoTask : MonoBehaviour,IBehaviourTreesTask 
    {
        public virtual void OnEnter() { }

        public virtual EBehaviourProcessState OnUpdate()
        {
            return EBehaviourProcessState.Success;
        }

        public virtual void OnExit() { }
    }
}