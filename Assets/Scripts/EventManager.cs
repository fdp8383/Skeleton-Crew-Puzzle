using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EventManager : MonoBehaviour
{
    public delegate Vector2 PositionDelegate(Vector2 initial);
    public static event PositionDelegate getPosition;

    public static Vector2 GetPosition(Vector2 initial)
    {
        return getPosition(initial);
    }
}
