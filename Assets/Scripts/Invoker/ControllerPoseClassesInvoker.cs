using Unity.XR.PXR;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Valve.VR;

public class ControllerPoseClassesInvoker : ClassesInvoker<XRController, SteamVR_Behaviour_Pose, MonoBehaviour, MonoBehaviour, PXR_HandPose, MonoBehaviour, MonoBehaviour, MonoBehaviour>
{
    public override void Invoke(SteamVR_Behaviour_Pose preportTypeClass, PXR_HandPose portedTypeClass)
    {
        portedTypeClass.trackType = (preportTypeClass.inputSource == SteamVR_Input_Sources.LeftHand) ? PXR_HandPose.TrackType.Left : PXR_HandPose.TrackType.Right;
    }

    public override void Invoke(PXR_HandPose preportTypeClass, SteamVR_Behaviour_Pose portedTypeClass)
    {
        portedTypeClass.inputSource = (preportTypeClass.trackType == PXR_HandPose.TrackType.Left) ? SteamVR_Input_Sources.LeftHand : SteamVR_Input_Sources.RightHand;
    }
}
