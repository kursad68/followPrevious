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

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * 4f*Time.deltaTime;
    }
}
