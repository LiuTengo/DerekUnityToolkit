using DerekToolkit.GeneralTool.BehaviourTrees.Base;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using UnityEditor.TerrainTools;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Decorator
{
    public class URepeatDecorator : UDecorator
    {
        public int repeateCount;
        
        private int count;

        public URepeatDecorator(int limit)
        {
            repeateCount = limit;
        }
        
        protected override void OnEnterState()
        {
            count = 0;
        }

        protected override EBehaviourProcessState OnUpdateState()
        {
            ChildBehaviourNode.Tick();
            
            if (ChildBehaviourNode.isFail)
                return EBehaviourProcessState.Fail;
            if (++count >= repeateCount)
                return EBehaviourProcessState.Success;
            
            return EBehaviourProcessState.Running;
        }

    }
}