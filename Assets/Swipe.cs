using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    Vector3 firstPressPos, secondPressPos, currentSwipe,SwipeCurrent;
    public float sensivity;
    public float NothingField=1.5f, clampOnAxis=6f,JumpToSens=50,jumpToMove=7,jumpForWait=1.5f,rotateSensRadian=30f;
    public bool isRotation;




    private Rigidbody rb;
    public Rigidbody Rb { get { return (rb == null) ? rb = GetComponent<Rigidbody>() : rb; } }


    private void OnEnable()
    {
        EventManager.GetScript += getS;
    }
    private void OnDisable()
    {
        EventManager.GetScript -= getS;
    }
    Swipe getS()
    {
        return GetComponent<Swipe>();
    }
    private void Update()
    {
        swipe();
        if (isRotation) {
            doRotation();
        }
        else
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 5 * Time.deltaTime);
        }
      
    }
    public void doRotation()
    {
      
        if (currentSwipe.x > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up * rotateSensRadian ), 5 * Time.deltaTime);
        }
        else if (currentSwipe.x < -0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Vector3.up * -rotateSensRadian), 5 * Time.deltaTime);
        }
        else 
        {
          
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0,0,0), 5 * Time.deltaTime);
        }
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
    }
    public void swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {

            firstPressPos = Input.mousePosition;
       

        }
        if (Input.GetMouseButton(0)==true)
        {
          

            secondPressPos = Input.mousePosition;

            currentSwipe = secondPressPos - firstPressPos;
            SwipeCurrent = currentSwipe;
            currentSwipe =currentSwipe.normalized;
          
        
            transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -clampOnAxis, clampOnAxis), Mathf.Clamp(transform.localPosition.y,-5f,5f), transform.localPosition.z);

          if (firstPressPos.x != secondPressPos.x || firstPressPos.y != secondPressPos.y)
            {
               
              
                //swipe left
                if (currentSwipe.x < 0)
                {
                    transform.localPosition += transform.right * sensivity  *.1f* SwipeCurrent.x*Time.deltaTime;



                }
                //swipe right
                if (currentSwipe.x > 0 )
                {
               
                    transform.localPosition += transform.right * sensivity *.1f * SwipeCurrent.x * Time.deltaTime;

                }
        
            }
            else
            {
                
            }
            firstPressPos = secondPressPos;
        }

     if(Input.GetMouseButton(0) == false)
        {
            currentSwipe.x = 0;
        }
         
    }

 
}
