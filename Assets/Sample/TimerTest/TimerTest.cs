using System;
using System.Collections;
using System.Collections.Generic;
using DerekToolkit.GeneralTool.Timer;
using UnityEngine;

public class TimerTest : MonoBehaviour
{
    private UDerekTimer m_Timer;

    public List<int> assignmentID = new List<int>();
    
    void Start()
    {
        m_Timer = new UDerekTimer();

        int count = 10;
        int i = m_Timer.AddTimeAssignment((id)=>{
            Debug.Log($"ID:{id},Count:{count}");
            count--;
        },1,4,10);
        assignmentID.Add(i);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            int count = 40;
            int i = m_Timer.AddTimeAssignment((id)=>{
                Debug.Log($"ID:{id},Count:{count}");
                count -= 3;
            },2,0,10);
            assignmentID.Add(i);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            m_Timer.RemoveTimeAssignment(assignmentID[0]);
            assignmentID.Remove(assignmentID[0]);
        }
        
        m_Timer.UpdateTimer();
    }
}
