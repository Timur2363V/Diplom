using dpn;
using Unity.XR.CoreUtils;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Wave.Essence;

public class RigClassesInvoker : ClassesInvoker<XROrigin, Player, MonoBehaviour, OVRCameraRig, MonoBehaviour, DpnCameraRig, WaveRig, CardboardReticlePointer>
{
    public override void Invoke(XROrigin preportTypeClass, Player portedTypeClass)
    {
        portedTypeClass.trackingOriginTransform = preportTypeClass.Origin.transform;
        portedTypeClass.hmdTransforms = new Transform[] { preportTypeClass.Camera.transform };
    }

    public override void Invoke(Player preportTypeClass, XROrigin portedTypeClass)
    {
        portedTypeClass.Origin = preportTypeClass.trackingOriginTransform.gameObject;
        portedTypeClass.Camera = FindObjectOfType<Camera>();
    }
}