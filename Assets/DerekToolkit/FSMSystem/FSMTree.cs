using System;
using System.Collections.Generic;
using UnityEngine;

namespace DerekToolkit.FSMSystem
{
    [Serializable]
    public class StateTreeDebugSetting
    {
        public Color fontColor = Color.green;
        public int fontSize = 25;
        public Rect rect;
    }
    
    /// <summary>
    /// ÉèÖÃ×´Ì¬ScriptableObject
    /// ×´Ì¬ÇÐ»»µÄ¾ßÌåÂß¼­µÈ
    /// </summary>
    public class FSMTree : MonoBehaviour
    {
        public DerekFSMStateBase[] states;
     
        private DerekFSMStateBase m_CurrentFsmState;
        private readonly Dictionary<string, DerekFSMStateBase> m_DerekStates = new ();
        
        #if UNITY_EDITOR
        public StateTreeDebugSetting stateTreeDebugSetting;
        #endif

        #region UnityFunction
        private void Start()
        {
            InitStates();
            EnterFirstState();
        }

        private void Update()
        {
            if (m_CurrentFsmState)
            {
                m_CurrentFsmState.OnUpdateState();
            }
        }

        private void FixedUpdate()
        {
            if (m_CurrentFsmState)
            {
                m_CurrentFsmState.OnFixedUpdateState();
            }
        }
        #endregion
        
        /// <summary>
        /// ÇÐ»»×´Ì¬
        /// </summary>
        /// <param name="stateName">×´Ì¬Ãû³Æ</param>
        /// <returns></returns>
        public bool SwitchState(string stateName)
        {
            if (m_CurrentFsmState != null && m_CurrentFsmState.name == stateName) return true;

            m_DerekStates.TryGetValue(stateName, out var s);
            if (s)
            {
                if (m_CurrentFsmState)
                {
                    m_CurrentFsmState.OnExitState();
                }
                m_CurrentFsmState = s;
                m_CurrentFsmState.OnEnterState();
                return true;
            }
            else
            {
                Debug.LogError($"Didn't find any state which called {stateName}");
                return false;
            }
        }

        /// <summary>
        /// Ìí¼Ó×Ó×´Ì¬µ½×Öµä
        /// </summary>
        /// <param name="stateName">×´Ì¬Ãû³Æ</param>
        /// <param name="fsmStateBase">×´Ì¬ÊµÀý</param>
        public void AddState(string stateName,DerekFSMStateBase fsmStateBase)
        {
            m_DerekStates.Add(stateName,fsmStateBase);
        }
        /// <summary>
        /// ³õÊ¼»¯×´Ì¬
        /// </summary>
        private void InitStates()
        {
            foreach (var s in states)
            {
                s.InitState(this);
            }
        }

        private void EnterFirstState()
        {
            foreach (var s in states)
            {
                if (s.CanEnterState())
                {
                    m_CurrentFsmState = s;
                    return;
                }
            }
        }
#if UNITY_EDITOR
        private void OnGUI()
        {
            //StateInfo
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = stateTreeDebugSetting.fontSize;
            labelStyle.normal.textColor = stateTreeDebugSetting.fontColor;
            GUI.Label(stateTreeDebugSetting.rect,m_CurrentFsmState.stateName,labelStyle);
        }
#endif
    }
}
