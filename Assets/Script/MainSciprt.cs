using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class MainSciprt : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cine;
    CinemachineTransposer CineTrans;
    private void OnEnable()
    {
        EventManager.mainS += mGet;
        EventManager.onCameraAction += cameraFollowinControl;
    }
    private void OnDisable()
    {
        EventManager.mainS += mGet;
        EventManager.onCameraAction -= cameraFollowinControl;
    }
    MainSciprt mGet()
    {
        return GetComponent<MainSciprt>();
    }
    private void Start()
    {
        EventManager.LocalSize = 0;
        CineTrans = cine.GetCinemachineComponent<CinemachineTransposer>();
    }
 
    private void cameraFollowinControl(int value)
    {
        //CineTrans.m_FollowOffset.z -= x;
        DOTween.To(() => CineTrans.m_FollowOffset.z, x => CineTrans.m_FollowOffset.z = x, CineTrans.m_FollowOffset.z - value, 1f);
    }
    void Update()
    {
        transform.position += Vector3.forward * 10f*Time.deltaTime;
    }
}
