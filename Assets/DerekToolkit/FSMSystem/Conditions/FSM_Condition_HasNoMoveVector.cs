using System;
using DerekToolkit.FSMSystem.Base;
using Sample.FSMTest;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Conditions
{
    [CreateAssetMenu(menuName = "DerekToolkit/FSM/Conditions/FSM_Condition_HasNoMoveVector",fileName = "FSM_Condition_HasNoMoveVector")]
    public class FSM_Condition_HasNoMoveVector : FSMBaseCondition
    {
        public bool isLockHorizontal = true;
        
        private DerekPlayerController m_PlayerController;
        
        public override void InitConditions(FSMBaseState state, GameObject actor)
        {
            m_PlayerController = actor.GetComponent<DerekPlayerController>();
        }

        public override bool IsFitCondition()
        {
            Vector3 v = m_PlayerController.MoveVector;
            if (isLockHorizontal)
            {
                return v.x < 0.0001f && v.z < 0.0001f;
            }
            else
            {
                return v.x < 0.0001f && v.z < 0.0001f && v.z < 0.0001f;
            }
        }
    }
}
