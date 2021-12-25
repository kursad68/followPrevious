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
    //values
    public static bool shoulder,body,head,handle;
    public static int shoulderSize, bodySize, headSize, handleSize;
    //action in
    public static Action<string,string> onAnimatorAction;
    public static Action<string> onAnimationPlay;
    //get
    public static Func<Swipe> GetScript;
    public static Func<MainSciprt> mainS;

    //unityEvent
    public static UnityEvent onCubeActiveTrue = new UnityEvent();
    public static UnityEvent onCubeActiveFalse = new UnityEvent();
    public static UnityEvent onFinalCubeActive= new UnityEvent();
    public static UnityEvent OnGameLost = new UnityEvent();
    public static UnityEvent OnGameWin = new UnityEvent();
}
