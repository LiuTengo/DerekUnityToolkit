using System;
using DerekToolkit.HFSMSystem.Interfaces;
using UnityEngine;

namespace DerekToolkit.HFSMSystem.Base
{
    public enum HFSMTransitionMode
    {
        OnTick, //每帧判断
        OnEvent, //事件模式
        OnStateCompleted, //状态完成时
        OnStateFailed //状态失败时
    }
    
    [Serializable]
    public class HFSMTransition : IHFSMTransition
    {
        /// <summary>
        /// 转换状态名称id（标识）
        /// </summary>
        [SerializeField] private string transitionName;
        public string TransitionName => transitionName;
        /// <summary>
        /// 切换条件检测时机
        /// </summary>
        [SerializeField] private HFSMTransitionMode trigger = HFSMTransitionMode.OnTick;
        public HFSMTransitionMode Trigger => trigger;
        /// <summary>
        /// 切换优先级
        /// </summary>
        [SerializeField] private int priority;
        public int Priority => priority;
        /// <summary>
        /// 起始状态
        /// </summary>
        private HFSMState m_Belonged;
        public HFSMState StartState => m_Belonged;
        /// <summary>
        /// 目标状态
        /// </summary>
        [SerializeField] private HFSMStateBase destination;
        public HFSMStateBase DestinationState => destination;
        /// <summary>
        /// 切换条件
        /// </summary>
        [SerializeField] private HFSMBaseCondition[] conditions;
        
        private Action<HFSMState,HFSMStateBase> m_SwitchStateTo;
        
        public void InitTransition(HFSMState state, HFSMController controller,GameObject actor)
        {
            m_Belonged = state;
            m_SwitchStateTo += controller.SwitchState;
            
            foreach (var c in conditions)
            {
                c.InitConditions(actor);
            }
        }

        public void CheckWhetherShouldTransition()
        {
            if (FitAllConditions())
            { 
                m_SwitchStateTo?.Invoke(StartState,DestinationState);
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