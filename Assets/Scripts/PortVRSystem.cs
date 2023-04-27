using UnityEditor.PackageManager;
using UnityEditor;
using UnityEngine;
using UnityEditor.PackageManager.Requests;

[ExecuteAlways]
public class PortVRSystem : MonoBehaviour
{
    [SerializeField]
    VRSystem currentSystem;
    [SerializeField]
    VRSystem portingSystem;

    [SerializeField]
    URLSystem[] URLSystems;

    AddRequest request;

    URLSystem GetURLSystem(VRSystem system)
    {
        for (int i = 0; i < URLSystems.Length; i++)
        {
            if (URLSystems[i].System == system)
            {
                return URLSystems[i];
            }
        }

        return null;
    }

    [ContextMenu("Invoke")]
    void Invoke()
    {
        var urlPortingSystem = GetURLSystem(portingSystem);
        request = Client.Add(urlPortingSystem.UrlVRSystem);
        EditorApplication.update += Progress;
    }

    void Progress()
    {
        if (request.IsCompleted)
        {
            if (request.Status == StatusCode.Success)
                Debug.Log("Installed: " + request.Result.packageId);
            else if (request.Status >= StatusCode.Failure)
                Debug.Log(request.Error.message);

            EditorApplication.update -= Progress;
            var urlPortingSystem = GetURLSystem(portingSystem);
            var urlCurrentSystem = GetURLSystem(currentSystem);
            urlPortingSystem.RigReplacer.Replace(urlCurrentSystem.RigReplacer.Rig);
            //urlPortingSystem.PlatformSwitcher.Switch();
            urlPortingSystem.Presettings.ReplaceSettings();
            urlPortingSystem.InteractiveObjectReplacer.Replace(urlCurrentSystem.InteractiveObjectReplacer.InteractableObject);
            urlPortingSystem.UIReplacer.Replace(urlCurrentSystem.UIReplacer);
        }
    }
}
