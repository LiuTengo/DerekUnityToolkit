using System;
using DerekToolkit.GeneralTool.FSM;
using DerekToolkit.GeneralTool.FSM.DefaultFSMTask;
using UnityEngine;

namespace Scenes.FSM
{
    public class FSMTest : MonoBehaviour
    {
        private UFSMController m_FsmController;

        private void Awake()
        {
            m_FsmController = new UFSMController();

            DebugLogFSMTask task01 = new DebugLogFSMTask("Task 01");
            DebugLogFSMTask task02 = new DebugLogFSMTask("Task 02");

            UFSMState debugState01 = new UFSMState(m_FsmController,task01);
            UFSMState debugState02 = new UFSMState(m_FsmController,task02);
            
            m_FsmController.AddState("State01",debugState01);
            m_FsmController.AddState("State02",debugState02);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_FsmController.SwitchState("State01");
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                m_FsmController.SwitchState("State02");
            }

            m_FsmController.FixedUpdate();
        }
    }
}