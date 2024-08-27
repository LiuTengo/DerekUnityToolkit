using UnityEngine;

namespace Scenes.SingletonTest
{
    public class SingletonMonoDebuger : MonoBehaviour
    {
        private void OnEnable()
        {
            Debug.Log(USingletonMonoTest.instance.GetRandomNumber());
        }

        private void OnDisable()
        {
            Debug.Log(USingletonMonoTest.instance.GetRandomNumber());
        }
    }
}