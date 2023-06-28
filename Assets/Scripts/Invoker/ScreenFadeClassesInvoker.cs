using Unity.XR.PXR;
using UnityEngine;
using Valve.VR;
using VRTK;

public class ScreenFadeClassesInvoker : ClassesInvoker<MonoBehaviour, SteamVR_Fade, VRTK_HeadsetCollisionFade, OVRScreenFade, PXR_ScreenFade, MonoBehaviour, MonoBehaviour, MonoBehaviour>
{
    public override void Invoke(OVRScreenFade preportTypeClass, PXR_ScreenFade portedTypeClass)
    {
        portedTypeClass.gradientTime = preportTypeClass.fadeTime;
        portedTypeClass.fadeColor = preportTypeClass.fadeColor;
    }

    public override void Invoke(OVRScreenFade preportTypeClass, VRTK_HeadsetCollisionFade portedTypeClass)
    {
        portedTypeClass.timeTillFade = preportTypeClass.fadeTime;
        portedTypeClass.fadeColor = preportTypeClass.fadeColor;
    }

    public override void Invoke(PXR_ScreenFade preportTypeClass, OVRScreenFade portedTypeClass)
    {
        portedTypeClass.fadeTime = preportTypeClass.gradientTime;
        portedTypeClass.fadeColor = preportTypeClass.fadeColor;
    }

    public override void Invoke(PXR_ScreenFade preportTypeClass, VRTK_HeadsetCollisionFade portedTypeClass)
    {
        portedTypeClass.timeTillFade = preportTypeClass.gradientTime;
        portedTypeClass.fadeColor = preportTypeClass.fadeColor;
    }

    public override void Invoke(VRTK_HeadsetCollisionFade preportTypeClass, OVRScreenFade portedTypeClass)
    {
        portedTypeClass.fadeTime = preportTypeClass.timeTillFade;
        portedTypeClass.fadeColor = preportTypeClass.fadeColor;
    }

    public override void Invoke(VRTK_HeadsetCollisionFade preportTypeClass, PXR_ScreenFade portedTypeClass)
    {
        portedTypeClass.gradientTime = preportTypeClass.timeTillFade;
        portedTypeClass.fadeColor = preportTypeClass.fadeColor;
    }
}