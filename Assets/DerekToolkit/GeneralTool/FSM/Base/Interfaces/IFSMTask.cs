namespace DerekToolkit.GeneralTool.FSM.Base.Interfaces
{
    public interface IFSMTask
    {
        public void OnEnterState();
        public void OnUpdate();
        public void OnFixedUpdate();
        public void OnLateUpdate();
        public void OnAnimateUpdate();
        public void OnExitState();
    }
}