using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EventManager : MonoBehaviour
{
    public delegate Vector2 DelegateName(Vector2 initial);
    public static event DelegateName EventName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector2 CallEvent(Vector2 initial)
    {
        return EventName(initial);
    }
}
