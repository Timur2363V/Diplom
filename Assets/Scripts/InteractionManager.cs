using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class InteractionManager
{
    [SerializeField]
    XRInteractionManager xRInteractionManager;
    [SerializeField]
    LocomotionSystem locomotionSystem;
    [SerializeField]
    LocomotionTeleport locomotionTeleport;
    [SerializeField]
    TeleportationProvider teleportationProvider;

    public void Invoke(VRSystem system)
    {
        if (system == VRSystem.OpenXR)
        {
            var interactionManager = new GameObject("XRInteractionManager").AddComponent<XRInteractionManager>();
            MonoBehaviourCopy.GetCopyOf(xRInteractionManager, interactionManager);
            var locomotion = new GameObject("LocomotionSystem").AddComponent<LocomotionSystem>();
            MonoBehaviourCopy.GetCopyOf(locomotionSystem, locomotion);
            var teleportation = new GameObject("TeleportationProvider").AddComponent<TeleportationProvider>();
            MonoBehaviourCopy.GetCopyOf(teleportationProvider, teleportation);
            DestroyPreportClasses<LocomotionTeleport>();
        }
        else if (system == VRSystem.OculusIntergration)
        {
            var locomotion = new GameObject("LocomotionSystem").AddComponent<LocomotionTeleport>();
            MonoBehaviourCopy.GetCopyOf(locomotionTeleport, locomotion);
            DestroyPreportClasses<LocomotionSystem>();
            DestroyPreportClasses<XRInteractionManager>();
            DestroyPreportClasses<TeleportationProvider>();
        }
        else
        {
            DestroyPreportClasses<LocomotionTeleport>();
            DestroyPreportClasses<LocomotionSystem>();
            DestroyPreportClasses<XRInteractionManager>();
            DestroyPreportClasses<TeleportationProvider>();
        }
    }

    private void DestroyPreportClasses<T>()
        where T : MonoBehaviour
    {
        var preportClasses = MonoBehaviour.FindObjectsOfType<T>();

        for (int i = 0; i < preportClasses.Length; i++)
        {
            MonoBehaviour.DestroyImmediate(preportClasses[i]);
        }
    }
}