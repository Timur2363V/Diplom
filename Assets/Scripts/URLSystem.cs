using System;
using UnityEngine;

[Serializable]
public class URLSystem
{
    [SerializeField]
    string urlVRSystem;
    [SerializeField]
    VRSystem system;
    [SerializeField]
    RigReplacer rigReplacer;
    //[SerializeField]
    //PlatformSwitcher platformSwitcher;
    [SerializeField]
    Presettings presettings;
    [SerializeField]
    InteractiveObjectReplacer interactiveObjectReplacer;
    [SerializeField]
    UIReplacer uIReplacer;
    [SerializeField]
    TeleportationReplacer teleportationReplacer;

    public VRSystem System => system;
    public string UrlVRSystem => urlVRSystem;
    internal RigReplacer RigReplacer => rigReplacer;
    //internal PlatformSwitcher PlatformSwitcher => platformSwitcher;
    internal Presettings Presettings => presettings;
    internal InteractiveObjectReplacer InteractiveObjectReplacer => interactiveObjectReplacer;
    internal UIReplacer UIReplacer => uIReplacer;
    internal TeleportationReplacer TeleportationReplacer => teleportationReplacer;
}