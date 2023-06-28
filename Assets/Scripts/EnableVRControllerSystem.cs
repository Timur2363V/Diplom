using System;
using UnityEngine;

[Serializable]
public class EnableVRControllerSystem
{
    [SerializeField]
    VrModeController vrModeController;

    public void Invoke(VRSystem system)
    {
        if (system == VRSystem.CardboardXRplugin)
        {
            var vrMode = new GameObject("VRModeController").AddComponent<VrModeController>();
            MonoBehaviourCopy.GetCopyOf(vrMode, vrModeController);
        }
        else
        {
            MonoBehaviour.DestroyImmediate(MonoBehaviour.FindObjectOfType<VrModeController>());
        }
    }
}