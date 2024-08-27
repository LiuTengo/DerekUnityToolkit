using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Interfaces;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base
{
    public class UBehaviourTreesTaskNode : UBehaviourNode
    {
        private IBehaviourTreesTask m_Task;

        public UBehaviourTreesTaskNode(IBehaviourTreesTask task)
        {
            m_Task = task;
        }
        
        protected override void OnEnterState()
        {
            m_Task.OnEnter();
        }

        protected override EBehaviourProcessState OnUpdateState()
        {
            return m_Task.OnUpdate();
        }

        protected override void OnExitState()
        {
            m_Task.OnEnter();
        }
    }
}
