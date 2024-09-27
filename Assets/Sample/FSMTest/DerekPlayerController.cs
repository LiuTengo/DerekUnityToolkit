using UnityEngine;
using UnityEngine.InputSystem;

namespace Sample.FSMTest
{
    /// <summary>
    /// ���ڴ�����������¼�����ɫ�ƶ��߼�����¼��ɫ�ƶ�����
    /// </summary>
    public class DerekPlayerController : MonoBehaviour
    {
        [SerializeField] private InputActionAsset playerInputMap;
        public float speed;
        private Vector3 moveDir;
        private Animator m_Animator;    
        public Vector3 MoveVector => moveDir;

        private void Start()
        {
            moveDir = Vector3.zero;
        
            m_Animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            moveDir.x = Input.GetAxis("Vertical"); 
            moveDir.z = -Input.GetAxis("Horizontal");
        
            Vector3 dir = moveDir;
            m_Animator.SetFloat("WalkX",dir.x);
            m_Animator.SetFloat("WalkZ",dir.z);
        
        }
    }
}
