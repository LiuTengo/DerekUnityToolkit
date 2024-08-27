using DerekToolkit.GeneralTool.BehaviourTrees.Base.Enumerations;

namespace DerekToolkit.GeneralTool.BehaviourTrees.Base
{
    public abstract class UBehaviourNode
    {
        private EBehaviourProcessState m_State;
        
        public bool isRunning => m_State == EBehaviourProcessState.Running;
        public bool isFail => m_State == EBehaviourProcessState.Fail;
        public bool isSuccess => m_State == EBehaviourProcessState.Success;
        public bool isInValid => m_State == EBehaviourProcessState.Invalid;
        public bool isValid => m_State == EBehaviourProcessState.Valid;

        public UBehaviourNode()
        {
            m_State = EBehaviourProcessState.Valid;
        }
        
        public EBehaviourProcessState Tick()
        {
            if (isInValid) return m_State;
            
            if (!isRunning)
            {
                OnEnterState();
            }
            m_State = OnUpdateState();
            if (!isRunning)
            {
                OnExitState();
            }

            return m_State;
        }
        
        public virtual void AddBehaviour(UBehaviourNode node) { }
        protected virtual void OnEnterState(){}
        protected abstract EBehaviourProcessState OnUpdateState();
        protected virtual void OnExitState(){}
        
        protected void InvalidBehaviour()
        {
            m_State = EBehaviourProcessState.Invalid;
        }
        protected void ResetBehaviour()
        {
            m_State = EBehaviourProcessState.Valid;
        }

        public void Abort()
        {
            OnExitState();
            m_State = EBehaviourProcessState.Abort;
        }
    }
}
