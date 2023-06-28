using HTC.UnityPlugin.Vive;
using Oculus.Interaction;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR.InteractionSystem;
using VRTK;

public class InteractableGrabClassesInvoker : ClassesInvoker<XRGrabInteractable, Throwable, VRTK_InteractableObject, Grabbable, MonoBehaviour, MonoBehaviour, BasicGrabbable, MonoBehaviour>
{
    public override void Invoke(Throwable preportTypeClass, XRGrabInteractable portedTypeClass)
    {
        portedTypeClass.attachTransform = preportTypeClass.attachmentOffset;
    }

    public override void Invoke(XRGrabInteractable preportTypeClass, Throwable portedTypeClass)
    {
        portedTypeClass.attachmentOffset = preportTypeClass.attachTransform;
    }
}