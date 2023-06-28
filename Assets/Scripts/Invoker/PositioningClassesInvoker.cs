using HTC.UnityPlugin.Vive;
using Oculus.Interaction.PoseDetection;
using UnityEditor.XR.LegacyInputHelpers;
using UnityEngine;

public class PositioningClassesInvoker : ClassesInvoker<CameraOffset, MonoBehaviour, MonoBehaviour, HmdOffset, MonoBehaviour, MonoBehaviour, CustomDeviceHeight, MonoBehaviour>
{
    public override void Invoke(CameraOffset preportTypeClass, HmdOffset portedTypeClass)
    {
        portedTypeClass._offsetTranslation = Vector3.up * preportTypeClass.cameraYOffset;
    }

    public override void Invoke(CameraOffset preportTypeClass, CustomDeviceHeight portedTypeClass)
    {
        portedTypeClass.height = preportTypeClass.cameraYOffset;
    }

    public override void Invoke(HmdOffset preportTypeClass, CameraOffset portedTypeClass)
    {
        portedTypeClass.cameraYOffset = preportTypeClass._offsetTranslation.y;
    }

    public override void Invoke(HmdOffset preportTypeClass, CustomDeviceHeight portedTypeClass)
    {
        portedTypeClass.height = preportTypeClass._offsetTranslation.y;
    }

    public override void Invoke(CustomDeviceHeight preportTypeClass, HmdOffset portedTypeClass)
    {
        portedTypeClass._offsetTranslation = Vector3.up * preportTypeClass.height;
    }

    public override void Invoke(CustomDeviceHeight preportTypeClass, CameraOffset portedTypeClass)
    {
        portedTypeClass.cameraYOffset = preportTypeClass.height;
    }
}
