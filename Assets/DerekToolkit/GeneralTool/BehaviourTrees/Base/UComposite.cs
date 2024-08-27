using System.Collections.Generic;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base
{
    public class UComposite : UBehaviourNode
    {

        protected LinkedList<UBehaviourNode> ChildBehaviourList = new();

        protected override EBehaviourProcessState OnUpdateState()
        {
            throw new System.NotImplementedException();
        }

        public override void AddBehaviour(UBehaviourNode node)
        {
            ChildBehaviourList.AddLast(node);
        }

        protected void Clear()
        {
            ChildBehaviourList.Clear();
        }

        protected void Remove(UBehaviourNode node)
        {
            ChildBehaviourList.Remove(node);
        }
    }
}