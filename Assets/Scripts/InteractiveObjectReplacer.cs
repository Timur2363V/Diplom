using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class InteractiveObjectReplacer
{
    [SerializeField]
    MonoBehaviour interactableObject;
    [SerializeField]
    MonoBehaviour socketInteractableObject;

    public MonoBehaviour InteractableObject => interactableObject;
    public MonoBehaviour SocketInteractableObject => socketInteractableObject;

    public void Replace(InteractiveObjectReplacer interactiveObjectReplacer)
    {
        var interactableObjects = MonoBehaviour.FindObjectsByType(interactiveObjectReplacer.InteractableObject.GetType(), FindObjectsSortMode.None);
        
        for (int i = 0; i < interactableObjects.Length; i++)
        {
            var interactableObjectInScene = interactableObjects[i].GameObject();
            MonoBehaviour.DestroyImmediate(interactableObjects[i]);
            interactableObjectInScene.AddComponent(interactableObject.GetType());
        }

        var socketInteractableObjects = MonoBehaviour.FindObjectsByType(interactiveObjectReplacer.SocketInteractableObject.GetType(), FindObjectsSortMode.None);

        for (int i = 0; i < socketInteractableObjects.Length; i++)
        {
            var socketInteractableObjectInScene = socketInteractableObjects[i].GameObject();
            MonoBehaviour.DestroyImmediate(socketInteractableObjects[i]);
            socketInteractableObjectInScene.AddComponent(socketInteractableObject.GetType());
        }
    }
}
