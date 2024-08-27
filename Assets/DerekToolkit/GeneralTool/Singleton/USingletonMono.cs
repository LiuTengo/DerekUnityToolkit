using System;
using UnityEngine;

namespace DerekToolkit.GeneralTool.Singleton
{
    public class USingletonMono<T> : MonoBehaviour where T : USingletonMono<T>
    {
        private static T _instance;

        public static T instance => _instance;

        protected virtual void Awake()
        {
            if(_instance) Destroy(_instance);
            _instance = this as T;
        }

        protected void OnDestroy()
        {
            if(_instance) Destroy(_instance);
        }
    }
}
