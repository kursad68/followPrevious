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

    void Update()
    {
        if (istriger&&type!=TypeEnm.main)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, new Vector3(previos.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z), 0.1f);
        }
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<enemy>())
        {
            if (!istriger)
            {
                m = EventManager.mainS.Invoke();
                parent = m.gameObject;
                transform.SetParent(parent.transform);

                previos = collision.gameObject;
                Debug.Log(previos.name);
                istriger = true;
            }
        }
    }
}
