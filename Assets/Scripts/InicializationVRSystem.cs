using dpn;
using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

[Serializable]
public class InicializationVRSystem
{
    [SerializeField]
    CardboardStartup inicializationCardboard;
    [SerializeField]
    InputModule inicializationSteamVR;
    [SerializeField]
    DpnStandaloneInputModule inicializationDPVR;

    public void Invoke(VRSystem system)
    {
        if (system == VRSystem.CardboardXRplugin)
        {
            var inicializationVRSystem = new GameObject("InicializationCardboard").AddComponent<CardboardStartup>();
            MonoBehaviourCopy.GetCopyOf(inicializationVRSystem, inicializationCardboard);
        }
        else if (system == VRSystem.SteamVR)
        {
            var inicializationVRSystem = new GameObject("InicializationSteamVR").AddComponent<InputModule>();
            MonoBehaviourCopy.GetCopyOf(inicializationVRSystem, inicializationSteamVR);
        }
        else if (system == VRSystem.DPVRSDK)
        {
            var inicializationVRSystem = new GameObject("InicializationDPVR").AddComponent<DpnStandaloneInputModule>();
            MonoBehaviourCopy.GetCopyOf(inicializationVRSystem, inicializationDPVR);
        }
    }
}