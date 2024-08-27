using System;
using DerekToolkit.GeneralTool.ObjectPool;
using DerekToolkit.GeneralTool.ObjectPool.Interfaces;
using UnityEngine;

namespace Sample.ObjectPool
{
    public class CubeGO : PoolGameObjectMono
    {
        public float duration = 3;
        public float tick = 0.0f;
        private Action<PoolGameObjectMono> callBack;
        public override void Initialize(IGameObjectPool pool)
        {
            callBack += pool.RecycleObject;
            Debug.Log("Initialize CubeGO");
            tick = 0.0f;
        }

        private void Update()
        {
            if (tick<duration)
            {
                tick += Time.deltaTime;
            }
            else
            {
                callBack?.Invoke(this);
            }
        }

        public override void OnReset(IGameObjectPool pool)
        {
            callBack += pool.RecycleObject;
            
            tick = 0.0f;
            gameObject.SetActive(true);
            Debug.Log("OnReset CubeGO");
        }

        public override void OnRecycle(IGameObjectPool pool)
        {
            callBack -= pool.RecycleObject;
            
            tick = 0.0f;
            gameObject.SetActive(false);
            Debug.Log("OnRecycle CubeGO");
        }
    }
}