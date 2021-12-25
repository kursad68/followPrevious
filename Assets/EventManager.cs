using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;
public enum CubeType
{
    shoulder,
    body,
    head,
    handle,
    Cube
}

public static class EventManager 
{
    
    public static int LocalSize;
    public static List<GameObject> Boxlist=new List<GameObject>();

    public static Func<Swipe> GetScript;
    public static Func<MainSciprt> mainS;
}
