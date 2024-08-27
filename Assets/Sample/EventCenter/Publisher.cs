using System;
using System.Collections;
using System.Collections.Generic;
using DerekToolkit.GeneralTool.EventCenter;
using UnityEngine;

public class Publisher : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            EventCenter.instance.CallEvent("TestEvent");
            EventCenter.instance.CallEvent("TestEvent");
        }   
    }
}
