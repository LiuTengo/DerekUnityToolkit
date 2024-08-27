using System;
using System.Collections.Generic;
using DerekToolkit.GeneralTool.EventCenter.EventLib;
using DerekToolkit.GeneralTool.Singleton;
using UnityEngine;

namespace DerekToolkit.GeneralTool.EventCenter
{
    public class EventCenter : USingletonMono<EventCenter>
    {
        private readonly Dictionary<string, IBaseEvent> m_EventLibrary = new Dictionary<string, IBaseEvent>();

        /// <summary>
        /// 调用事件
        /// </summary>
        /// <param name="eventName">事件名称</param>
        public void CallEvent(string eventName)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo info = m_EventLibrary[eventName] as EventInfo;
                if (info != null)
                {
                    info.Events?.Invoke();
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void CallEvent<T>(string eventName,T t)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T> info = m_EventLibrary[eventName] as EventInfo<T>;
                if (info != null)
                {
                    info.Events?.Invoke(t);
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void CallEvent<T1,T2>(string eventName,T1 t1,T2 t2)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2> info = m_EventLibrary[eventName] as EventInfo<T1,T2>;
                if (info != null)
                {
                    info.Events?.Invoke(t1,t2);
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void CallEvent<T1,T2,T3>(string eventName,T1 t1,T2 t2,T3 t3)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3> info = m_EventLibrary[eventName] as EventInfo<T1,T2,T3>;
                if (info != null)
                {
                    info.Events?.Invoke(t1,t2,t3);
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void CallEvent<T1,T2,T3,T4>(string eventName,T1 t1,T2 t2,T3 t3,T4 t4)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3,T4> info = m_EventLibrary[eventName] as EventInfo<T1,T2,T3,T4>;
                if (info != null)
                {
                    info.Events?.Invoke(t1,t2,t3,t4);
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
        public void CallEvent<T1,T2,T3,T4,T5>(string eventName,T1 t1,T2 t2,T3 t3,T4 t4,T5 t5)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3,T4,T5> info = m_EventLibrary[eventName] as EventInfo<T1,T2,T3,T4,T5>;
                if (info != null)
                {
                    info.Events?.Invoke(t1,t2,t3,t4,t5);
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        /// <summary>
        /// 注册并添加一个事件
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <param name="newEvent">无参方法</param>
        public void RegisterEvent(string eventName, Action newEvent)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo info = m_EventLibrary[eventName] as EventInfo;
                if (info != null)
                {
                    info.Events+=newEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
            else 
            {
                m_EventLibrary.Add(eventName,new EventInfo(newEvent));
            }
        }
    
        public void RegisterEvent<T>(string eventName, Action<T> newEvent)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T> info = m_EventLibrary[eventName] as EventInfo<T>;
                if (info != null)
                {
                    info.Events+=newEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
            else 
            {
                m_EventLibrary.Add(eventName,new EventInfo<T>(newEvent));
            }
        }
    
        public void RegisterEvent<T1,T2>(string eventName, Action<T1,T2> newEvent)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2> info = m_EventLibrary[eventName] as EventInfo<T1,T2>;
                if (info != null)
                {
                    info.Events+=newEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
            else 
            {
                m_EventLibrary.Add(eventName,new EventInfo<T1,T2>(newEvent));
            }
        }
    
        public void RegisterEvent<T1,T2,T3>(string eventName, Action<T1,T2,T3> newEvent)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3> info = m_EventLibrary[eventName] as EventInfo<T1,T2,T3>;
                if (info != null)
                {
                    info.Events+=newEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
            else 
            {
                m_EventLibrary.Add(eventName,new EventInfo<T1,T2,T3>(newEvent));
            }
        }
    
        public void RegisterEvent<T1,T2,T3,T4>(string eventName, Action<T1,T2,T3,T4> newEvent)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3,T4> info = m_EventLibrary[eventName] as EventInfo<T1,T2,T3,T4>;
                if (info != null)
                {
                    info.Events+=newEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
            else 
            {
                m_EventLibrary.Add(eventName,new EventInfo<T1,T2,T3,T4>(newEvent));
            }
        }
    
        public void RegisterEvent<T1,T2,T3,T4,T5>(string eventName, Action<T1,T2,T3,T4,T5> newEvent)
        {
            if (m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3,T4,T5> info = m_EventLibrary[eventName] as EventInfo<T1,T2,T3,T4,T5>;
                if (info != null)
                {
                    info.Events+=newEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
            else 
            {
                m_EventLibrary.Add(eventName,new EventInfo<T1,T2,T3,T4,T5>(newEvent));
            }
        }
    
        /// <summary>
        /// 移除事件
        /// </summary>
        /// <param name="eventName"></param>
        public void RemoveEvent(string eventName,Action removedEvent) 
        {
            if(m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo info = (m_EventLibrary[eventName] as EventInfo);
                if (info != null)
                {
                    info.Events-=removedEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void RemoveEvent<T>(string eventName,Action<T> removedEvent) 
        {
            if(m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T> info = (m_EventLibrary[eventName] as EventInfo<T>);
                if (info != null)
                {
                    info.Events-=removedEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void RemoveEvent<T1,T2>(string eventName,Action<T1,T2> removedEvent) 
        {
            if(m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2> info = (m_EventLibrary[eventName] as EventInfo<T1,T2>);
                if (info != null)
                {
                    info.Events-=removedEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void RemoveEvent<T1,T2,T3>(string eventName,Action<T1,T2,T3> removedEvent) 
        {
            if(m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3> info = (m_EventLibrary[eventName] as EventInfo<T1,T2,T3>);
                if (info != null)
                {
                    info.Events-=removedEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void RemoveEvent<T1,T2,T3,T4>(string eventName,Action<T1,T2,T3,T4> removedEvent) 
        {
            if(m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3,T4> info = (m_EventLibrary[eventName] as EventInfo<T1,T2,T3,T4>);
                if (info != null)
                {
                    info.Events-=removedEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        public void RemoveEvent<T1,T2,T3,T4,T5>(string eventName,Action<T1,T2,T3,T4,T5> removedEvent) 
        {
            if(m_EventLibrary.ContainsKey(eventName))
            {
                EventInfo<T1,T2,T3,T4,T5> info = (m_EventLibrary[eventName] as EventInfo<T1,T2,T3,T4,T5>);
                if (info != null)
                {
                    info.Events-=removedEvent;
                }
                else
                {
                    Debug.LogWarning("EventInfo is null!");   
                }
            }
        }
    
        /// <summary>
        /// 删除事件
        /// </summary>
        /// <param name="eventName"></param>
        public void DeleteEvent(string eventName) 
        {
            if (m_EventLibrary.ContainsKey(eventName)) 
            {
                m_EventLibrary.Remove(eventName);
            }
        }

        public void Clear() 
        {
            m_EventLibrary.Clear();
        }
    
    }
}
