using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBus 
{
    private static Dictionary<Type, Delegate> eventTable = new Dictionary<Type, Delegate>();
    //订阅
    public static void Subscribe<T>(Action<T> callback)
    {
        if(eventTable.TryGetValue(typeof(T),out Delegate de))
        {
            eventTable[typeof(T)] = Delegate.Combine(de, callback);
            return;
        }
        eventTable.Add(typeof(T), callback);
    }
    //负责发布和分发给订阅者（让订阅这个事件的触发）
    public static void Publish<T>(T eventData)
    {
        if(eventTable.TryGetValue(typeof(T),out Delegate de))
        {
            (de as Action<T>)?.Invoke(eventData);
        }
    }
    //取消订阅
    public static void UnSubscribe<T>(Action<T> action)
    {
        if(eventTable.TryGetValue(typeof(T),out Delegate de))
        {
            Delegate newDelegate = Delegate.Remove(de,action);
            if (newDelegate == null)
            {
                eventTable.Remove(typeof(T));
            }
            else
            {
                eventTable[typeof(T)] = newDelegate;
            }
        }
    }
}
