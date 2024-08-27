using DerekToolkit.GeneralTool.BehaviourTrees.Base;

namespace DerekToolkit.GeneralTool.BehaviourTrees
{
    public class UBehaviourTrees
    {
        public bool hasRoot => m_Root != null;
        private UBehaviourNode m_Root;

        public UBehaviourTrees(UBehaviourNode node)
        {
            m_Root = node;
        }

        public void Tick()
        {
            m_Root.Tick();
        }

        public void SetBehaviourTreesRoot(UBehaviourNode node)
        {
            m_Root = node;
        }
    }
}