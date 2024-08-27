using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base.Interfaces
{
    public interface IBehaviourTreesTask
    {
        public void OnEnter();
        public EBehaviourProcessState OnUpdate();
        public void OnExit();
    }
}