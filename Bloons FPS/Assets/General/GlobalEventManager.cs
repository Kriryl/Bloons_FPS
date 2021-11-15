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
        print(eventName + " called.");
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
        print(eventName + " called.");
    }
}
