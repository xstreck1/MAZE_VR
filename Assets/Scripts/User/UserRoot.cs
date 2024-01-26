using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UserRoot : MonoBehaviour
{
    [SerializeField] private GameObject xrRig;
    [SerializeField] private GameObject pcRig;

    private void Awake()
    {
#if UNITY_ANDROID 
        xrRig.SetActive(true);
        pcRig.SetActive(false);
#else
        bool isVRDevice = CheckVRDevice();
        if (isVRDevice)
        {
            xrRig.SetActive(true);
            pcRig.SetActive(false);
        }
        else
        {
            xrRig.SetActive(false);
            pcRig.SetActive(true);
        }
#endif
    }

    bool CheckVRDevice()
    {
        var xrDisplaySubsystems = new List<XRDisplaySubsystem>();
        SubsystemManager.GetInstances(xrDisplaySubsystems);

        foreach (var displaySubsystem in xrDisplaySubsystems)
        {
            Debug.Log($"A VR device found: {displaySubsystem.SubsystemDescriptor.id}");
            return true;
        }
        Debug.Log("No active VR device found.");
        return false;
    }
}