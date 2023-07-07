using System;
using System.Collections;
using System.Collections.Generic;

public class SystemEventManager
{
    public enum SystemEventType
    {
        BuildingPlaced,
        BuildModeEntered,
        UnitSeen,
        QuestCreated
    }

    private static Dictionary<SystemEventType, Action<object>> _eventListeners;

    public static void Init()
    {
        _eventListeners = new Dictionary<SystemEventType, Action<object>>();
    }

    public static void Subscribe(SystemEventType type, Action<object> action)
    {
        _eventListeners ??= new Dictionary<SystemEventType, Action<object>>();
        if (!_eventListeners.TryGetValue(type, out var e)) return;
        
        if (e != null)
        {
            _eventListeners[type] += action;
        }
        else
        {
            e = action;
            _eventListeners[type] = e;
        }
    }
    
    public static void Unsubscribe(SystemEventType type, Action<object> action)
    {
        if (!_eventListeners.TryGetValue(type, out var e)) return;
        
        if (e != null)
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
