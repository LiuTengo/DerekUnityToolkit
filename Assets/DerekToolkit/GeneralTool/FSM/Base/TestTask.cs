using DerekToolkit.GeneralTool.FSM.Base.Interfaces;
using UnityEngine;

namespace DerekToolkit.GeneralTool.FSM.Base
{
    [CreateAssetMenu(fileName = "TestTask", menuName = "FSM/StateTask")]
    public class TestTask : ScriptableObject,IFSMTask
    {
        public int idInfo;
        
        public void OnEnterState()
        {
            throw new System.NotImplementedException();
        }

        public void OnUpdate()
        {
            Debug.Log(idInfo.ToString());
        }

        public void OnFixedUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnLateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnAnimateUpdate()
        {
            throw new System.NotImplementedException();
        }

        public void OnExitState()
        {
            throw new System.NotImplementedException();
        }
    }
}