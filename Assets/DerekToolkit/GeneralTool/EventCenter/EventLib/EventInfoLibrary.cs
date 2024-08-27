using System;

namespace DerekToolkit.GeneralTool.EventCenter.EventLib
{
    public class EventInfo : IBaseEvent
    {
        public Action Events;

        public EventInfo(Action newEvents)
        {
            Events += newEvents;
        }

    }
    public class EventInfo<T> : IBaseEvent
    {
        public Action<T> Events;
    
        public EventInfo(Action<T> newEvents)
        {
            Events += newEvents;
        }

    }
    public class EventInfo<T1,T2> : IBaseEvent
    {
        public Action<T1,T2> Events;
    
        public EventInfo(Action<T1,T2> newEvents)
        {
            Events += newEvents;
        }
    }
    public class EventInfo<T1,T2,T3> : IBaseEvent
    {
        public Action<T1,T2,T3> Events;
    
        public EventInfo(Action<T1,T2,T3> newEvents)
        {
            Events += newEvents;
        }
    
        public void AddEvent(Action<T1,T2,T3> eventInfo)
        {
            Events += eventInfo;
        }
    }
    public class EventInfo<T1,T2,T3,T4> : IBaseEvent
    {
        public Action<T1,T2,T3,T4> Events;
    
        public EventInfo(Action<T1,T2,T3,T4> newEvents)
        {
            Events += newEvents;
        }
    
        public void AddEvent(Action<T1,T2,T3,T4> eventInfo)
        {
            Events += eventInfo;
        }
    }
    public class EventInfo<T1,T2,T3,T4,T5> : IBaseEvent
    {
        public Action<T1,T2,T3,T4,T5> Events;
    
        public EventInfo(Action<T1,T2,T3,T4,T5> newEvents)
        {
            Events += newEvents;
        }
    
        public void AddEvent(Action<T1,T2,T3,T4,T5> eventInfo)
        {
            Events += eventInfo;
        }
    }
}