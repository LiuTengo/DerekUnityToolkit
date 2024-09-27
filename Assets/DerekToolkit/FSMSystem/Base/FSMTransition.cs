using System;
using DerekToolkit.FSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.FSMSystem.Base
{
    public enum FSMTransitionMode
    {
        OnTick, //每帧判断
        //OnEvent, //事件模式
        OnStateCompleted, //状态完成时
        OnStateFailed //状态失败时
    }
    
    [Serializable]
    public class FSMTransition : IFSMTransition
    {
        [SerializeField] private FSMTransitionMode trigger = FSMTransitionMode.OnTick;
        [SerializeField] private int priority;
        [SerializeField] private string destination;
        [SerializeField] private FSMBaseCondition[] conditions;

        private Action<string> m_SwitchStateTo;
        public virtual void InitTransition(FSMBaseState state, GameObject actor)
        {
            m_SwitchStateTo += state.SwitchState;
            
            switch (trigger)
            {
                case FSMTransitionMode.OnTick:
                    state.onTaskRun += CheckWhetherShouldTransition;        
                    break;
                case FSMTransitionMode.OnStateCompleted:
                    state.onTaskCompleted += CheckWhetherShouldTransition;
                    break;
                case FSMTransitionMode.OnStateFailed:
                    state.onTaskFailed += CheckWhetherShouldTransition;
                    break;
            }
            
            foreach (var c in conditions)
            {
                c.InitConditions(state,actor);
            }
        }

        public virtual void CheckWhetherShouldTransition()
        {
            if (FitAllConditions())
            {
                m_SwitchStateTo?.Invoke(destination);
            }
        }

        private bool FitAllConditions()
        {
            if (conditions.Length <= 0) return true;

            foreach (var c in conditions)
            {
                if (!c.IsFitCondition()) return false;
            }

            return true;
        }
    }
}
