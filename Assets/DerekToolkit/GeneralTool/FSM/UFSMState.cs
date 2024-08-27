using System.Threading.Tasks;
using DerekToolkit.GeneralTool.FSM.Base.Interfaces;

namespace DerekToolkit.GeneralTool.FSM
{
    public class UFSMState
    {
        protected UFSMController fsmController;
        protected IFSMTask fsmTask;
        
        public UFSMState(UFSMController fsmController, IFSMTask task)
        {
            this.fsmController = fsmController;
            this.fsmTask = task;
        }

        //进入当前状态时调用
        public void EnterState()
        {
            fsmTask.OnEnterState();
        }

        //当前状态时每帧调用一次
        public void UpdateState()
        {
            fsmTask.OnUpdate();
        }

        public void FiexedUpdate()
        {
            fsmTask.OnFixedUpdate();
        }
        
        public void LateUpdate()
        {
            fsmTask.OnLateUpdate();
        }

        public void AnimateUpdate()
        {
            fsmTask.OnAnimateUpdate();
        }

        //退出当前状态时调用
        public void ExitState()
        {
            fsmTask.OnExitState();
        }

    }
}
