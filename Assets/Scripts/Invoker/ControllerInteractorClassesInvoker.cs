using dpn;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerInteractorClassesInvoker : ClassesInvoker<XRDirectInteractor, Valve.VR.InteractionSystem.Hand, MonoBehaviour, OVRHand, MonoBehaviour, MonoBehaviour, MonoBehaviour, DPVR_Controller>
{
    public override void Invoke(XRDirectInteractor preportTypeClass, Valve.VR.InteractionSystem.Hand portedTypeClass)
    {
        portedTypeClass.objectAttachmentPoint = preportTypeClass.attachTransform;
    }

    public override void Invoke(Valve.VR.InteractionSystem.Hand preportTypeClass, XRDirectInteractor portedTypeClass)
    {
        portedTypeClass.attachTransform = preportTypeClass.objectAttachmentPoint;
    }
}
