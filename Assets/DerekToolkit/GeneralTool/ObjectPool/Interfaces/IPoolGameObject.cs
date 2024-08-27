namespace DerekToolkit.GeneralTool.ObjectPool.Interfaces
{
    /// <summary>
    /// 对象池中的对象接口
    /// </summary>
    public interface IPoolGameObject
    {
        /// <summary>
        /// 初次生成时调用
        /// </summary>
        public void Initialize(IGameObjectPool pool);
        
        /// <summary>
        /// 从初次生成以及从对象池中获取物体时调用
        /// </summary>
        public void OnReset(IGameObjectPool pool);
        
        /// <summary>
        /// 回收物体时调用
        /// </summary>
        public void OnRecycle(IGameObjectPool pool);
    }
}