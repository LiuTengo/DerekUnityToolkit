using UnityEngine;

namespace DerekToolkit.HFSMSystem.Base
{
    [CreateAssetMenu(menuName = "DerekToolkit/HFSM/State/HFSMState",fileName = "HFSMState")]
    public class HFSMState : HFSMStateBase
    {
        public HFSMBaseTask task;
        public HFSMTransition[] transitions;
        public override void InitState(GameObject owner, HFSMController hfsmController)
        {
            if (task)
            {
                task.InitTask(owner);   
            }
            
            foreach (var transition in transitions)
            {
                if (transition!=null)
                {
                    transition.InitTransition(this,hfsmController,owner);
                    task.AddSwitchRequest(transition);
                }
            }
        }

        public override void OnEnterState()
        {
            if (task)
            {
                task.OnTaskStart();
            }
        }

        public override void OnUpdateState()
        {
            if (task)
            {
                task.OnTaskUpdate();
            }
        }

        public override void OnFixedUpdateState()
        {
            if (task)
            {
                task.OnTaskFixedUpdate();
            }
        }

        public override void OnExitState()
        {
            if (task)
            {
                task.OnTaskFinish();
            }
        }

        public override bool OnExitRequest()
        {
            return true;
        }

        public override string GetCurrentStateName()
        {
            return stateName;
        }
    }
}