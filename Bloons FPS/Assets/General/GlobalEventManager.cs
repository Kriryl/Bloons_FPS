using UnityEngine;

/// <summary>
/// Class for handling global events.
/// </summary>
public class GlobalEventManager : MonoBehaviour
{
    /// <summary>
    /// Calls the method eventName on every Monobehaviour.
    /// </summary>
    /// <param name="eventName">The method name.</param>
    public static void CallEvent(string eventName)
    {
        MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            monoBehaviour.BroadcastMessage(eventName, SendMessageOptions.DontRequireReceiver);
        }
    }
    /// <summary>
    /// Calls the method eventName on every Monobehaviour, and passes in _object as a parameter.
    /// </summary>
    /// <param name="eventName">The method name.</param>
    /// <param name="_Object">The object to pass in.</param>
    public static void CallEvent(string eventName, object _Object)
    {
        MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            monoBehaviour.BroadcastMessage(eventName, _Object, SendMessageOptions.DontRequireReceiver);
        }
    }

    /// <summary>
    /// A class used to store info about an event call.
    /// </summary>
    public class EventInfo
    {
        public BloonType[] children;
        public GameObject _Object;

        public EventInfo(BloonType[] children, GameObject _Object)
        {
            this.children = children;
            this._Object = _Object;
        }
    }

    /// <summary>
    /// Calls the method eventName on every Monobehaviour, and passes in eventInfo as a parameter.
    /// </summary>
    /// <param name="eventName">The name of the method to call.</param>
    /// <param name="eventInfo">The info you want passed in the method.</param>
    public static void CallEvent(string eventName, EventInfo eventInfo)
    {
        MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour monoBehaviour in monoBehaviours)
        {
            monoBehaviour.BroadcastMessage(eventName, eventInfo, SendMessageOptions.DontRequireReceiver);
        }
    }
}
