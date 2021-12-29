using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum TypeEnm
{
    enemy,
    main
}
public class enemy : MonoBehaviour
{
    private bool istriger;
    private GameObject previos,parent;
    MainSciprt m;
    [SerializeField]
    private TypeEnm type;
    int i = 0;
    void Update()
    {
        if (istriger&&type!=TypeEnm.main)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(previos.transform.localPosition.x, previos.transform.localPosition.y,i), 0.1f); 
        }  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<Swipe>())
        {
            if (!istriger)
            {
                JustDoİt();
            }
        }
    }
    private void JustDoİt()
    {
        gameObject.layer = 8;
        istriger = true;
        m = EventManager.mainS.Invoke();
        parent = m.gameObject;
        transform.SetParent(parent.transform);
        EventManager.LocalSize--;
        i = EventManager.LocalSize;  
        EventManager.Boxlist.Add(gameObject);
        previos = EventManager.Boxlist[-i - 1];
        EventManager.onCameraAction.Invoke(1);
    }
}
