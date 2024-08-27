using System.Collections.Generic;
using DerekToolkit.GeneralTool.BehaviourTrees.Base;
using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;
using UnityEngine;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Composite
{
    public class USequenceComposite : UComposite
    {
        private LinkedListNode<UBehaviourNode> m_CurrentNode;
        private UBehaviourNode m_CurrentBehaviour;
        protected override void OnEnterState()
        {
            m_CurrentNode = ChildBehaviourList.First;
            m_CurrentBehaviour = m_CurrentNode.Value;
        }

        protected override EBehaviourProcessState OnUpdateState()
        {
            while (true)
            {
                var s = m_CurrentBehaviour.Tick();
                if (s != EBehaviourProcessState.Success) return s;
                
                m_CurrentNode = m_CurrentNode.Next;
            
                if (m_CurrentNode != null)
                {
                    m_CurrentBehaviour = m_CurrentNode.Value;
                    return EBehaviourProcessState.Running;
                }
                
                return EBehaviourProcessState.Success;
            }
        }
    }
}