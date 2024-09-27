using System;
using DerekToolkit.CustomProperty;
using DerekToolkit.FSMSystem.Base;
using UnityEngine;

namespace DerekToolkit.FSMSystem
{
    [Serializable]
    public class FSMDebugSetting
    {
        public Color fontColor = Color.green;
        public int fontSize = 25;
        public Rect rect;
    }
    
    public class FSMController : MonoBehaviour
    {
        [SerializeField]private FSMRootState statesRoot;
        
        #if UNITY_EDITOR
        [Header("µ˜ ‘…Ë÷√  DebugSetting")]
        [SerializeField]private FSMDebugSetting debugSetting;
        #endif
        
        // Start is called before the first frame update
        private void Start()
        {
            statesRoot.InitState(null,this.gameObject);

            statesRoot.OnEnterState();
        }

        // Update is called once per frame
        private void Update()
        {
            statesRoot.OnUpdateState();
        }

        private void FixedUpdate()
        {
            statesRoot.OnFixedUpdateState();
        }

#if UNITY_EDITOR
        private void OnGUI()
        {
            string stateName = statesRoot.GetCurrentStateName();
            GUIStyle labelStyle = new GUIStyle();
            labelStyle.fontSize = debugSetting.fontSize;
            labelStyle.normal.textColor = debugSetting.fontColor;
            GUI.Label(debugSetting.rect,"FSM"+stateName,labelStyle);
        }
#endif
    }
}