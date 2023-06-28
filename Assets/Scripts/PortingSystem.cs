using System;
using UnityEngine;

[Serializable]
public class PortingSystem
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
    //[SerializeField]
    //InteractiveObjectReplacer interactiveObjectReplacer;
    [SerializeField]
    UIReplacer uIReplacer;
    //[SerializeField]
    //ReplacerScripts replacerScripts;

    public VRSystem System => system;
    public string UrlVRSystem => urlVRSystem;
    //public ReplacerScripts ReplacerScripts => replacerScripts;
    public RigReplacer RigReplacer => rigReplacer;
    //internal PlatformSwitcher PlatformSwitcher => platformSwitcher;
    public Presettings Presettings => presettings;
    //internal InteractiveObjectReplacer InteractiveObjectReplacer => interactiveObjectReplacer;
    public UIReplacer UIReplacer => uIReplacer;
}