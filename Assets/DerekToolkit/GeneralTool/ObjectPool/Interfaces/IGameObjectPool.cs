namespace DerekToolkit.GeneralTool.ObjectPool.Interfaces
{
    /// <summary>
    /// 对象池接口
    /// </summary>
    public interface IGameObjectPool
    {
        /// <summary>
        /// 从对象池中获取物体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where T : PoolGameObjectMono;
        /// <summary>
        /// 回收某物体
        /// </summary>
        /// <param name="poolGo"></param>
        public void RecycleObject(PoolGameObjectMono poolGo);
        /// <summary>
        /// 清除所有物体
        /// </summary>
        public void ClearAll();
    }
}