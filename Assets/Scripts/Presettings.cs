using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

[Serializable]
class Presettings
{
    [SerializeField]
    BuildTargetGroup group;
    [SerializeField]
    BuildTarget platform;
    [SerializeField]
    GraphicsDeviceType[] graphicsDeviceTypes;
    [SerializeField]
    ApiCompatibilityLevel apiCompatibilityLevel;
    [SerializeField]
    ScriptingImplementation scriptingImplementation;

    public void ReplaceSettings()
    {
        PlayerSettings.SetGraphicsAPIs(platform, graphicsDeviceTypes);
        PlayerSettings.SetApiCompatibilityLevel(group, apiCompatibilityLevel);
        PlayerSettings.SetScriptingBackend(group, scriptingImplementation);
    }
}