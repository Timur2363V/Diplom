using HTC.UnityPlugin.Vive;
using Unity.XR.PXR;
using UnityEngine;

public class HMDSettingClassesInvoker : ClassesInvoker<MonoBehaviour, MonoBehaviour, MonoBehaviour, OVRManager, PXR_Manager, MonoBehaviour, VRCameraHook, MonoBehaviour>
{
    public override void Invoke(OVRManager preportTypeClass, PXR_Manager portedTypeClass)
    {
        portedTypeClass.useRecommendedAntiAliasingLevel = preportTypeClass.useRecommendedMSAALevel;
    }

    public override void Invoke(PXR_Manager preportTypeClass, OVRManager portedTypeClass)
    {
        portedTypeClass.useRecommendedMSAALevel = preportTypeClass.useRecommendedAntiAliasingLevel;
    }
}
