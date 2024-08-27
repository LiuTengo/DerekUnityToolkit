using DerekToolkit.GeneralTool.FSM.Base.Interfaces;

namespace DerekToolkit.GeneralTool.FSM.Base.Task
{
    public class UFSMTask : IFSMTask
    {
        public virtual void OnEnterState() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnLateUpdate() { }
        public virtual void OnAnimateUpdate() { }
        public virtual void OnExitState() { }
    }
}