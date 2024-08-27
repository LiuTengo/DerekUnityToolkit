using DerekToolkit.GeneralTool.ObjectPool.Interfaces;
using UnityEngine;

namespace DerekToolkit.GeneralTool.ObjectPool
{
    /// <summary>
    /// 对象池物体基类，所有对象池物体应继承该类
    /// </summary>
    public class PoolGameObjectMono : MonoBehaviour,IPoolGameObject
    {
        protected IGameObjectPool m_GoPool;
        
        private int id;
        public int ID => id;

        public void SetID(int index)
        {
            id = index;
        }

        public virtual void Initialize(IGameObjectPool pool)
        {
            m_GoPool = pool;
        }

        public virtual void OnReset(IGameObjectPool pool)
        {
            m_GoPool = pool;
        }

        public virtual void OnRecycle(IGameObjectPool pool)
        {
            m_GoPool.RecycleObject(this);
        }
    }
}