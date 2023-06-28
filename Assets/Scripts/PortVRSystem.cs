using UnityEditor.PackageManager;
using UnityEditor;
using UnityEngine;
using UnityEditor.PackageManager.Requests;

[ExecuteAlways]
public class PortVRSystem : MonoBehaviour
{
    [SerializeField]
    VRSystem currentSystem;
    [SerializeField]
    VRSystem portingSystem;
    [SerializeField]
    PortingSystem[] PresettingsSystems;
    [SerializeField]
    ControllerInteractorClassesInvoker controllerInteractor;
    [SerializeField]
    ControllerInteractorUIClassesInvoker controllerInteractorUI;
    [SerializeField]
    ControllerPoseClassesInvoker controllerPose;
    [SerializeField]
    ControllerRayInteractorClassesInvoker controllerRayInteractor;
    [SerializeField]
    ControllerRayVisualClassesInvoker controllerRayVisual;
    [SerializeField]
    GrabMoveControllerClassesInvoker grabMoveController;
    [SerializeField]
    HMDSettingClassesInvoker hmdSettingClasses;
    [SerializeField]
    InteractableClassesInvoker interactable;
    [SerializeField]
    InteractableGrabClassesInvoker interactableGrab;
    [SerializeField]
    MoveControllerClassesInvoker moveController;
    [SerializeField]
    PositioningClassesInvoker positioning;
    [SerializeField]
    RigClassesInvoker rig;
    [SerializeField]
    RotationControllerClassesInvoker rotationController;
    [SerializeField]
    ScreenFadeClassesInvoker screenFade;
    [SerializeField]
    SimulatorClassesInvoker simulator;
    [SerializeField]
    SocketInteractableClassesInvoker socketInteractable;
    [SerializeField]
    TeleportationAnchorClassesInvoker teleportationAnchor;
    [SerializeField]
    TeleportationAreaClassesInvoker teleportationArea;
    [SerializeField]
    TooltipClassesInvoker tooltip;
    [SerializeField]
    EnableVRControllerSystem enableVRController;
    [SerializeField]
    InicializationVRSystem inicializationVRSystem;
    [SerializeField]
    InteractionManager interactionManager;

    AddRequest request;

    PortingSystem GetURLSystem(VRSystem system)
    {
        for (int i = 0; i < PresettingsSystems.Length; i++)
        {
            if (PresettingsSystems[i].System == system)
            {
                return PresettingsSystems[i];
            }
        }

        return null;
    }

    [ContextMenu("Invoke")]
    void Invoke()
    {
        var urlPortingSystem = GetURLSystem(portingSystem);
        if (urlPortingSystem.UrlVRSystem != "")
            request = Client.Add(urlPortingSystem.UrlVRSystem);
        EditorApplication.update += Progress;
    }

    void Progress()
    {
        if (request == null || request.IsCompleted)
        {
            if (request != null)
                if (request.Status == StatusCode.Success)
                    Debug.Log("Installed: " + request.Result.packageId);
                else if (request.Status >= StatusCode.Failure && request.Error != null)
                    Debug.Log(request.Error.message);

            EditorApplication.update -= Progress;
            var urlPortingSystem = GetURLSystem(portingSystem);
            var urlCurrentSystem = GetURLSystem(currentSystem);
            controllerInteractor.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            controllerInteractorUI.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            controllerPose.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            controllerRayInteractor.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            controllerRayVisual.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            grabMoveController.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            hmdSettingClasses.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            interactable.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            interactableGrab.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            moveController.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            positioning.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            if (urlPortingSystem.System != VRSystem.VRTK)
                rig.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            rotationController.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            screenFade.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            simulator.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            socketInteractable.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            teleportationAnchor.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            teleportationArea.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            tooltip.Invoke(urlCurrentSystem.System, urlPortingSystem.System);
            urlPortingSystem.RigReplacer.Replace(urlCurrentSystem.RigReplacer.Rig);
            //urlPortingSystem.PlatformSwitcher.Switch();
            urlPortingSystem.Presettings.ReplaceSettings();
            //urlPortingSystem.InteractiveObjectReplacer.Replace(urlCurrentSystem.InteractiveObjectReplacer);
            urlPortingSystem.UIReplacer.Replace(urlCurrentSystem.UIReplacer);
            //urlPortingSystem.ReplacerScripts.Replace(urlCurrentSystem.ReplacerScripts);
            enableVRController.Invoke(urlPortingSystem.System);
            inicializationVRSystem.Invoke(urlPortingSystem.System);
            interactionManager.Invoke(urlPortingSystem.System);
        }
    }
}
