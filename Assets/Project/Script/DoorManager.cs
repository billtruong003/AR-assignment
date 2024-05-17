using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class DoorManager : MonoBehaviour
{
    [SerializeField] private Transform mainCamera;
    public bool ready = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        FaceDoorToCam();
    }

    public void SetCam(Transform cam)
    {
        mainCamera = cam;
    }

    private void FaceDoorToCam()
    {
        if (ready || mainCamera == null)
            return;

        transform.LookAt(mainCamera.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y * 2, 0);
    }
}