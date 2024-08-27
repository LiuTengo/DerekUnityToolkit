namespace DerekToolkit.GeneralTool.ObjectPool.Interfaces
{
    /// <summary>
    /// ������еĶ���ӿ�
    /// </summary>
    public interface IPoolGameObject
    {
        /// <summary>
        /// ��������ʱ����
        /// </summary>
        public void Initialize(IGameObjectPool pool);
        
        /// <summary>
        /// �ӳ��������Լ��Ӷ�����л�ȡ����ʱ����
        /// </summary>
        public void OnReset(IGameObjectPool pool);
        
        /// <summary>
        /// ��������ʱ����
        /// </summary>
        public void OnRecycle(IGameObjectPool pool);
    }
}