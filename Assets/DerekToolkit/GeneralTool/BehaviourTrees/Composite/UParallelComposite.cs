using DerekToolkit.GeneralTool.BehaviourTrees.Base;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Composite
{
    public class UParallelComposite : UComposite
    {
        private EParallelBehaviourPolicy m_SuccessPolicy;
        private EParallelBehaviourPolicy m_FailPolicy;

        private int m_SuccessCount;
        private int m_FailCount;
        private int m_SuccessLimitCount;
        private int m_FailLimitCount;
        private int m_Size;

        public UParallelComposite(EParallelBehaviourPolicy successPolicy,EParallelBehaviourPolicy failPolicy)
        {
            m_SuccessPolicy = successPolicy;
            m_FailPolicy = failPolicy;
        }
        protected override void OnEnterState()
        {
            m_Size = ChildBehaviourList.Count;
            
            m_SuccessLimitCount = m_SuccessPolicy == EParallelBehaviourPolicy.One ? 1 : m_Size;
            m_FailLimitCount = m_FailPolicy == EParallelBehaviourPolicy.One ? 1 : m_Size;
        }

        protected override EBehaviourProcessState OnUpdateState()
        {
            foreach (var b in ChildBehaviourList)
            {
                var s = b.Tick();

                if (s == EBehaviourProcessState.Success)
                {
                    m_SuccessCount++;
                    if (m_SuccessCount >= m_SuccessLimitCount)
                        return EBehaviourProcessState.Success;
                }
                else if (s == EBehaviourProcessState.Fail)
                {
                    m_FailCount++;
                    if (m_FailCount >= m_FailLimitCount)
                        return EBehaviourProcessState.Fail;
                }
            }

            return EBehaviourProcessState.Running;
        }

        protected override void OnExitState()
        {
            foreach (var b in ChildBehaviourList)
            {
                b.Abort();
            }
        }
    }
}
