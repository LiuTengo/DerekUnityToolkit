using DerekToolkit.FSMSystem.Base;
using Sample.FSMTest;
using Unity.VisualScripting;
using UnityEngine;

namespace DerekToolkit.FSMSystem.FSMStateTask
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/Tasks/FSM_ActionTask",fileName = "FSM_ActionTask")]
    public class FSM_ActionTask : FSMBaseTask
    {
        public string stateName;
        private Animator m_Animator;
        private DerekPlayerController m_Controller;
        public override void InitTask(GameObject actor)
        {
            base.InitTask(actor);
            if (actor)
            {
                m_Animator = actor.GetComponent<Animator>();
                m_Controller = actor.GetComponent<DerekPlayerController>();
            }
            else
            {
                Debug.LogError("Actor is null");
            }
        }

        public override void OnTaskStart()
        {
            base.OnTaskStart();
            m_Animator.Play(stateName);
        }

    }
}
