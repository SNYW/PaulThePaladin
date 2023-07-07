using System;
using System.Collections;
using System.Collections.Generic;

public class SystemEventManager
{
    public enum SystemEventType
    {
        BuildingPlaced,
        UnitSeen,
        QuestCreated
    }

    private static Dictionary<SystemEventType, Action<object>> _eventListeners;


    public static void Subscribe(SystemEventType type, Action<object> action)
    {
        if (_eventListeners.TryGetValue(type, out var e))
        {
            _eventListeners[type] += action;
        }
    }
    
    public static void Unsubscribe(SystemEventType type, Action<object> action)
    {
        if (_eventListeners.TryGetValue(type, out var e))
        {
            _eventListeners[type] -= action;
        }
    }

    public static void RaiseEvent(SystemEventType type, object payload)
    {
        if (_eventListeners.TryGetValue(type, out var e))
        {
          e.Invoke(payload);
        }
    }

}
