using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class TeleportationReplacer
{
    [SerializeField]
    MonoBehaviour teleportationAnchor;
    [SerializeField]
    MonoBehaviour teleportationArea;

    public MonoBehaviour TeleportationAnchor => teleportationAnchor;
    public MonoBehaviour TeleportationArea => teleportationArea;

    public void Replace(TeleportationReplacer teleportationReplacer)
    {
        if (teleportationReplacer.TeleportationAnchor != null)
        {
            var teleportationAnchors = MonoBehaviour.FindObjectsByType(teleportationReplacer.TeleportationAnchor.GetType(), FindObjectsSortMode.None);

            for (int i = 0; i < teleportationAnchors.Length; i++)
            {
                var teleportationAnchorInScene = teleportationAnchors[i].GameObject();
                MonoBehaviour.DestroyImmediate(teleportationAnchors[i]);
                if (teleportationAnchor != null)
                    teleportationAnchorInScene.AddComponent(teleportationAnchor.GetType());
            }
        }

        if (teleportationReplacer.TeleportationArea != null)
        {
            var teleportationAreas = MonoBehaviour.FindObjectsByType(teleportationReplacer.TeleportationArea.GetType(), FindObjectsSortMode.None);

            for (int i = 0; i < teleportationAreas.Length; i++)
            {
                var teleportationAreaInScene = teleportationAreas[i].GameObject();
                MonoBehaviour.DestroyImmediate(teleportationAreas[i]);
                if (teleportationArea != null)
                    teleportationAreaInScene.AddComponent(teleportationArea.GetType());
            }
        }
    }
}
