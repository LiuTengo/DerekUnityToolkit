using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Interfaces;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base.DefaultBehavioursTreesTask
{
    public class UBehaviourTreesTask : IBehaviourTreesTask
    {
        public virtual void OnEnter() { }

        public virtual EBehaviourProcessState OnUpdate()
        {
            return EBehaviourProcessState.Success;
        }

        public virtual void OnExit() { }
    }
}