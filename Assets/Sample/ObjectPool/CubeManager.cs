using System;
using DerekToolkit.GeneralTool.ObjectPool;
using UnityEngine;

namespace Sample.ObjectPool
{
    public class CubeManager : MonoBehaviour
    {
        public VectorGameObjectPool GOPool;
        private void Start()
        {
            GOPool = GetComponent<VectorGameObjectPool>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var cube = GOPool.Get<CubeGO>();
                Debug.Log("Spawn Cube: "+cube.name);
            }
        }
    }
}