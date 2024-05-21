using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class VFXManager : Singleton<VFXManager>
{

    [SerializeField] private Transform aRCam;
    [SerializeField] private Vector3 poseUpdate;
    [Header("Flash Game Over")]
    [SerializeField] private ParticleSystem flash;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        fixPose();
    }

    [Button]
    public void activeFlashSmoke()
    {
        flash.Pause();
        flash.Play();
    }

    [Button]
    private void deactiveFlashSmoke()
    {
        // flash.SetActive(true);
    }

    private void fixPose()
    {
        float posZ = aRCam.position.z;
        poseUpdate = new Vector3(0, 0, posZ + 5);
        transform.position = poseUpdate;
        Debug.Log("Update Pose");
    }
}
