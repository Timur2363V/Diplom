using dpn;
using HTC.UnityPlugin.Vive;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using VRTK;

public class TeleportationAnchorClassesInvoker : ClassesInvoker<TeleportationAnchor, Valve.VR.InteractionSystem.TeleportPoint, VRTK_DestinationPoint, TeleportPoint, MonoBehaviour, Teleport, Teleportable, MonoBehaviour>
{
    public override void Invoke(TeleportationAnchor preportTypeClass, Teleportable portedTypeClass)
    {
        portedTypeClass.pivot = preportTypeClass.teleportAnchorTransform;
    }

    public override void Invoke(TeleportationAnchor preportTypeClass, TeleportPoint portedTypeClass)
    {
        portedTypeClass.destTransform = preportTypeClass.teleportAnchorTransform;
    }

    public override void Invoke(TeleportationAnchor preportTypeClass, VRTK_DestinationPoint portedTypeClass)
    {
        portedTypeClass.destinationLocation = preportTypeClass.teleportAnchorTransform;
    }

    public override void Invoke(TeleportPoint preportTypeClass, Teleportable portedTypeClass)
    {
        portedTypeClass.pivot = preportTypeClass.destTransform;
    }

    public override void Invoke(TeleportPoint preportTypeClass, TeleportationAnchor portedTypeClass)
    {
        portedTypeClass.teleportAnchorTransform = preportTypeClass.destTransform;
    }

    public override void Invoke(TeleportPoint preportTypeClass, VRTK_DestinationPoint portedTypeClass)
    {
        portedTypeClass.destinationLocation = preportTypeClass.destTransform;
    }

    public override void Invoke(Valve.VR.InteractionSystem.TeleportPoint preportTypeClass, VRTK_DestinationPoint portedTypeClass)
    {
        portedTypeClass.enableTeleport = !preportTypeClass.locked;
    }

    public override void Invoke(VRTK_DestinationPoint preportTypeClass, TeleportationAnchor portedTypeClass)
    {
        portedTypeClass.teleportAnchorTransform = preportTypeClass.destinationLocation;
    }

    public override void Invoke(VRTK_DestinationPoint preportTypeClass, Teleportable portedTypeClass)
    {
        portedTypeClass.pivot = preportTypeClass.destinationLocation;
    }

    public override void Invoke(VRTK_DestinationPoint preportTypeClass, TeleportPoint portedTypeClass)
    {
        portedTypeClass.destTransform = preportTypeClass.destinationLocation;
    }

    public override void Invoke(VRTK_DestinationPoint preportTypeClass, Valve.VR.InteractionSystem.TeleportPoint portedTypeClass)
    {
        portedTypeClass.locked = !preportTypeClass.enableTeleport;
    }

    public override void Invoke(Teleportable preportTypeClass, TeleportationAnchor portedTypeClass)
    {
        portedTypeClass.teleportAnchorTransform = preportTypeClass.pivot;
    }

    public override void Invoke(Teleportable preportTypeClass, TeleportPoint portedTypeClass)
    {
        portedTypeClass.destTransform = preportTypeClass.pivot;
    }

    public override void Invoke(Teleportable preportTypeClass, VRTK_DestinationPoint portedTypeClass)
    {
        portedTypeClass.destinationLocation = preportTypeClass.pivot;
    }
}