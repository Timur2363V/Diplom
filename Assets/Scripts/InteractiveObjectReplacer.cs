using System;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
class InteractiveObjectReplacer
{
    [SerializeField]
    MonoBehaviour interactableObject;

    public MonoBehaviour InteractableObject => interactableObject;

    public void Replace(MonoBehaviour interactableObjectToFind)
    {
        var interactableObjects = MonoBehaviour.FindObjectsByType(interactableObjectToFind.GetType(), FindObjectsSortMode.None);
        
        for (int i = 0; i < interactableObjects.Length; i++)
        {
            var interactableObjectInScene = interactableObjects[i].GameObject();
            MonoBehaviour.DestroyImmediate(interactableObjects[i]);
            interactableObjectInScene.AddComponent(interactableObject.GetType());
        }
    }
}
