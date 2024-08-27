using System;
using System.Collections.Generic;
using DerekToolkit.CustomAttribute;
using DerekToolkit.GeneralTool.ObjectPool.Interfaces;
using UnityEngine;

namespace DerekToolkit.GeneralTool.ObjectPool
{
    /// <summary>
    /// 行为类似C++的vector，当对象池满时再次从对象池中获取物体最大容量会扩增原长的2倍
    /// </summary>
    [Serializable]
    public class VectorGameObjectPool : MonoBehaviour, IGameObjectPool
    {
        [SerializeField] private GameObject prefabs;
        [SerializeField] private int maxCapacity;
        [SerializeField,ReadOnly]private int m_ActiveCount;
        private List<PoolGameObjectMono> showedPool = new List<PoolGameObjectMono>();
        private int m_InactivatedCount;
        private Queue<PoolGameObjectMono> m_UnusedPool = new Queue<PoolGameObjectMono>();
        private int m_IndexCount;

        private void Awake()
        {
            m_ActiveCount = 0;
            m_InactivatedCount = maxCapacity;
        }
        
        public T Get<T>() where T : PoolGameObjectMono
        {
            if (m_ActiveCount>=maxCapacity)
            {
                maxCapacity *= 2;
            }
            return GetObjectFromPool<T>();
        }
        
        public void RecycleObject(PoolGameObjectMono poolGo)
        {   
            poolGo.OnRecycle(this);
            var go = showedPool.Find(s =>
            {
                if (poolGo == null)
                {
                    return false;
                }

                return poolGo.ID == s.ID;
            });
            
            m_UnusedPool.Enqueue(go);
            showedPool.Remove(go);
            m_InactivatedCount++;
            m_ActiveCount = Math.Max(0,--m_ActiveCount);
        }
        
        public void ClearAll()
        {
            showedPool.ForEach(item=>{
                item.OnRecycle(this);
            });
            showedPool.Clear();
            m_UnusedPool.Clear();
            m_ActiveCount = 0;
            m_InactivatedCount = 0;
        }

        private T GetObjectFromPool<T>() where T : PoolGameObjectMono
        {
            if (m_UnusedPool.Count == 0)
            {
                return SpawnObject<T>();
            }
            else
            {
                //get exist object in unused game object pool
                var go = m_UnusedPool.Dequeue();
                showedPool.Add(go);
                
                go.OnReset(this);
                
                m_ActiveCount ++;
                m_InactivatedCount--;

                try
                {
                    return (T)go;
                }
                catch
                {
                    throw new System.InvalidCastException();
                }
            }
        } 
        
        private T SpawnObject<T>() where T : PoolGameObjectMono
        {
            try
            {
                var obj = Instantiate(prefabs);
                var pgoComponent = obj.GetComponent<PoolGameObjectMono>();
                
                showedPool.Add(pgoComponent);
                
                pgoComponent.Initialize(this);
                pgoComponent.OnReset(this);
                
                m_ActiveCount ++;
                m_InactivatedCount = Math.Max(0,--m_InactivatedCount);

                int id = GetPoolGOID();
                pgoComponent.SetID(id);
                
                return (T)pgoComponent;
            }
            catch
            {
                throw new System.NullReferenceException();
            }
        }

        private int GetPoolGOID()
        {
            m_IndexCount++;
            return m_IndexCount;
        }
    }
}