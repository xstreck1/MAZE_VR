using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class UserRoot : MonoBehaviour
{
    [SerializeField] private UserRig xrRig;
    [SerializeField] private UserRig pcRig;

    private UserRig activeRig;

    private void Awake()
    {
#if UNITY_ANDROID 
        xrRig.gameObject.SetActive(true);
        pcRig.gameObject.SetActive(false);
        activeRig = xrRig;
#else
        bool isVRDevice = CheckVRDevice();
        if (isVRDevice)
        {
            xrRig.gameObject.SetActive(true);
            pcRig.gameObject.SetActive(false);
            activeRig = xrRig;
        }
        else
        {
            xrRig.gameObject.SetActive(false);
            pcRig.gameObject.SetActive(true);
            activeRig = pcRig;
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
    
    public void DisplayMessage(string message, float duration = 5.0f)
    {
        activeRig.DisplayMessage(message, duration);
    }
}