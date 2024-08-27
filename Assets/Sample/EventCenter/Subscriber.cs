using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Subscriber : MonoBehaviour
{
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //EventCenter._instance.AddEventListener("TestEvent",RecieveMessage);
        //EventCenter._instance.AddEventListener("TestEvent", Message2);
        //EventCenter._instance.AddEventListener("TestEvent", ()=>StartCoroutine(TestCoroutine()));
    }

    void RecieveMessage() 
    {
        Debug.Log("message1!");
    }
    void Message2() 
    {
        Debug.Log("message2!");
    }
    IEnumerator TestCoroutine() 
    {
        while (time<1)
        {
            time+= Time.deltaTime;
            Debug.Log("Time:" + time);
            yield return null;
        }
    }
}
