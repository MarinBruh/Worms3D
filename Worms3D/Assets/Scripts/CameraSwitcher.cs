using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    private CinemachineVirtualCamera virtualCamera;
    private int priorityBoostAmount = 10;
    
    void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            StartAim();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            CancelAim();
        }
    }
    
    void StartAim()
    {
        virtualCamera.Priority += priorityBoostAmount;
    }
    void CancelAim()
    {
        virtualCamera.Priority -= priorityBoostAmount;
    }
}
