using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base
{
    public class UDecorator : UBehaviourNode
    {
        public UBehaviourNode ChildBehaviourNode;
        
        public override void AddBehaviour(UBehaviourNode node)
        {
            ChildBehaviourNode = node;
        }
        
        protected override EBehaviourProcessState OnUpdateState()
        {
            throw new System.NotImplementedException();
        }
    }
}