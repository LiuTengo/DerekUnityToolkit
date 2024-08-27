using DerekToolkit.GeneralTool.BehaviourTrees.Base;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Decorator
{
    public class UInvertDecorator : UDecorator
    {
        protected override EBehaviourProcessState OnUpdateState()
        {
            ChildBehaviourNode.Tick();
            
            if (ChildBehaviourNode.isSuccess)
                return EBehaviourProcessState.Fail;
            if (ChildBehaviourNode.isFail)
                return EBehaviourProcessState.Success;

            return EBehaviourProcessState.Running;
        }
    }
}