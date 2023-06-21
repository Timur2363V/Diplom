using System;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
class PlatformSwitcher
{
    [SerializeField]
    BuildTarget platform;

    public void Switch()
    {
        switch (platform)
        {
            case BuildTarget.StandaloneWindows:
                SwitchPlatformToDesktop();
                break;
            case BuildTarget.iOS:
                SwitchPlatformToIOS();
                break;
            default:
                SwitchPlatformToAndroid();
                break;
        }
    }

    void SwitchPlatformToDesktop()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.StandaloneWindows)
            SwitchTo(BuildTarget.StandaloneOSX);
    }

    void SwitchPlatformToIOS()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.iOS)
            SwitchTo(BuildTarget.iOS);
    }

    void SwitchPlatformToAndroid()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android)
            SwitchTo(BuildTarget.Android);
    }

    void SwitchTo(BuildTarget targetPlatform)
    {
        var currentPlatform = EditorUserBuildSettings.activeBuildTarget;
        if (currentPlatform == targetPlatform)
            return;

        // Don't switch when compiling
        if (EditorApplication.isCompiling)
        {
            Debug.LogWarning("Could not switch platform because unity is compiling");
            return;
        }

        // Don't switch while playing
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            Debug.LogWarning("Could not switch platform because unity is in playMode");
            return;
        }

        Debug.Log("Switching platform from " + currentPlatform + " to " + targetPlatform);

        string libDir = "Library";
        string libDirCurrent = libDir + "_" + currentPlatform;
        string libDirTarget = libDir + "_" + targetPlatform;

        // If target dir doesn't exist yet, make a copy of the current one
        if (!Directory.Exists(libDirTarget))
        {
            Debug.Log("Making a copy of " + libDir + " because " + libDirTarget + " doesn't exist yet");
            CopyFilesRecursively(new DirectoryInfo(libDir), new DirectoryInfo(libDirTarget));
        }

        // Safety check, libDirCurrent shouldn't exist (current data is stored in libDir)
        if (Directory.Exists(libDirCurrent))
            Directory.Delete(libDirCurrent, true);

        // Rename dirs
        Directory.Move(libDir, libDirCurrent);
        Directory.Move(libDirTarget, libDir);

        EditorUserBuildSettings.SwitchActiveBuildTarget(targetPlatform);
        Debug.Log("Platform switched to " + targetPlatform);
    }


    void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
    {
        foreach (DirectoryInfo dir in source.GetDirectories())
            CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));

        foreach (FileInfo file in source.GetFiles())
            file.CopyTo(Path.Combine(target.FullName, file.Name));
    }
}