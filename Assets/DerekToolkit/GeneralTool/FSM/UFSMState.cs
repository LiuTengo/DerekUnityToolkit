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

        //���뵱ǰ״̬ʱ����
        public void EnterState()
        {
            fsmTask.OnEnterState();
        }

        //��ǰ״̬ʱÿ֡����һ��
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

        //�˳���ǰ״̬ʱ����
        public void ExitState()
        {
            fsmTask.OnExitState();
        }

    }
}
