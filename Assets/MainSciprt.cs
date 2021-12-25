using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSciprt : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.mainS += mGet;
    }
    private void OnDisable()
    {
        EventManager.mainS += mGet;
    }
    MainSciprt mGet()
    {
        return GetComponent<MainSciprt>();
    }
    private void Start()
    {
        EventManager.LocalSize = 0;
        EventManager.Boxlist.Add(this.gameObject);
        Debug.Log(EventManager.Boxlist[0].name);
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * 10f*Time.deltaTime;
    }
}
