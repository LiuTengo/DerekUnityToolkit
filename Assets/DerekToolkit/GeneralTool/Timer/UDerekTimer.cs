using System;
using System.Collections.Generic;

namespace DerekToolkit.GeneralTool.Timer
{
    class TimeAssignment
    {
        public readonly int AssignmentID;
        public readonly double CompleteTime; // 完成单次任务所需时间
        public readonly Action<int> CallBack;
        
        public double NextCallBackTime; //运行时间 
        public int RecycleCount;  //重复次数
        
        public TimeAssignment
            (int id,double generateTime,double dest, Action<int> callBack,
            double delay,int recycle)
        {
            AssignmentID = id;
            CompleteTime = dest;
            CallBack = callBack;
            RecycleCount = recycle;
            NextCallBackTime = generateTime + delay + CompleteTime;
        }
    }
    
    /// <summary>
    /// 计时器系统
    /// </summary>
    public class UDerekTimer
    {
        private int m_CurrentID;
        private DateTime m_StartTime;
        
        private List<int> m_AssignmentsID;
        public List<int> m_DeleteTimeAssignments;
        private List<int> m_RecycleTimeAssignments;

        private List<TimeAssignment> m_TempTimeAssignments;
        private List<TimeAssignment> m_TimeAssignments;
        
        public UDerekTimer()
        {
            Reset();
        }

        /// <summary>
        /// 必须在 Update / FixedUpdate 中调用
        /// </summary>
        public void UpdateTimer()
        {
            CheckTimeAssignment();
            DeleteTimeAssignment();

            if (m_RecycleTimeAssignments.Count > 0)
            {
                RecycleAssignmentID();
            }
        }

        /// <summary>
        /// 添加计时任务
        /// </summary>
        /// <param name="callBack">回调函数</param>
        /// <param name="dest">调用时间</param>
        /// <param name="delay">延迟时间</param>
        /// <param name="recycle">循环次数</param>
        /// <returns>返回即使任务的ID</returns>
        public int AddTimeAssignment(Action<int> callBack,double dest,double delay = 0.0f,int recycle = 1)
        {
            double runTime = GetRunTime();
            int id = GetAssignmentID();
            TimeAssignment assignment = new TimeAssignment(id,runTime,dest,callBack,delay,recycle);
            
            m_TempTimeAssignments.Add(assignment);
            
            return id;
        }
        
        /// <summary>
        /// 移除ID对应的计时任务
        /// </summary>
        /// <param name="assignmentID">任务ID</param>
        public void RemoveTimeAssignment(int assignmentID)
        {
            m_DeleteTimeAssignments.Add(assignmentID);
        }

        private void Reset()
        {
            m_CurrentID = 0;
            m_StartTime = DateTime.Now;
            
            m_AssignmentsID = new List<int>();
            m_RecycleTimeAssignments = new List<int>();
            m_DeleteTimeAssignments = new List<int>();

            m_TempTimeAssignments = new List<TimeAssignment>();
            m_TimeAssignments = new List<TimeAssignment>();
        }
        
        private void CheckTimeAssignment()
        {
            m_TimeAssignments.AddRange(m_TempTimeAssignments);
            m_TempTimeAssignments.Clear();
            
            double runTime = GetRunTime();
            m_TimeAssignments.RemoveAll(assignment=>
            {
                if (runTime >= assignment.NextCallBackTime)
                {
                    assignment.CallBack?.Invoke(assignment.AssignmentID);
                    if (assignment.RecycleCount > 1)
                    {
                        assignment.RecycleCount--;
                        assignment.NextCallBackTime += assignment.CompleteTime;
                        return false;
                    }
                    else
                    {
                        m_RecycleTimeAssignments.Add(assignment.AssignmentID);
                        return true;
                    }
                }
                return false;
            });
        }

        private void DeleteTimeAssignment()
        {
            foreach (var deleteID in m_DeleteTimeAssignments)
            {
                TimeAssignment assignment = m_TimeAssignments.Find(a => (a.AssignmentID == deleteID));
                if (assignment != null)
                {
                    m_TimeAssignments.Remove(assignment);
                    m_RecycleTimeAssignments.Add(deleteID);
                }

                assignment = m_TempTimeAssignments.Find(a => (a.AssignmentID == deleteID));
                if (assignment != null)
                {
                    m_TempTimeAssignments.Remove(assignment);
                    m_RecycleTimeAssignments.Add(deleteID);
                }
            }
            m_DeleteTimeAssignments.Clear();
        }
        
        private int GetAssignmentID()
        {
            m_CurrentID ++;
            while (m_AssignmentsID.Contains(m_CurrentID))
            {
                if (m_CurrentID == int.MaxValue) m_CurrentID = 0;
                m_CurrentID++;
            }
            m_AssignmentsID.Add(m_CurrentID);
            return m_CurrentID;
        }

        private void RecycleAssignmentID()
        {
            m_RecycleTimeAssignments.ForEach((a)=>m_AssignmentsID.Remove(a));
            m_RecycleTimeAssignments.Clear();
        }
        
        private double GetRunTime()
        {
            return (DateTime.Now-m_StartTime).TotalSeconds;
        }
    }
}
