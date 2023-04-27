using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
class UIReplacer
{
    [SerializeField]
    MonoBehaviour canvasRaycaster;
    [SerializeField]
    MonoBehaviour eventSystem;
    [SerializeField]
    MonoBehaviour uIElement;
    [SerializeField]
    MonoBehaviour interactableUIElement;

    public MonoBehaviour CanvasRaycaster => canvasRaycaster;
    public MonoBehaviour EventSystem => eventSystem;
    public MonoBehaviour UIElement => uIElement;
    public MonoBehaviour InteractableUIElement => interactableUIElement;

    public void Replace(UIReplacer uIReplacer)
    {
        var interactableObjects = MonoBehaviour.FindObjectsByType(uIReplacer.CanvasRaycaster.GetType(), FindObjectsSortMode.None);

        for (int i = 0; i < interactableObjects.Length; i++)
        {
            var interactableObjectInScene = interactableObjects[i].GameObject();
            MonoBehaviour.DestroyImmediate(interactableObjects[i]);
            interactableObjectInScene.AddComponent(canvasRaycaster.GetType());
        }

        var eventSystemRaycasterInScene = MonoBehaviour.FindAnyObjectByType(uIReplacer.EventSystem.GetType());
        var eventSystemInScene = MonoBehaviour.FindAnyObjectByType(typeof(EventSystem));
        var inputModule = MonoBehaviour.FindAnyObjectByType(typeof(StandaloneInputModule));
        MonoBehaviour.DestroyImmediate(inputModule);

        var eventSystemInSceneObject = eventSystemInScene.GameObject();
        MonoBehaviour.DestroyImmediate(eventSystemRaycasterInScene);
        eventSystemInSceneObject.AddComponent(eventSystem.GetType());

        var uiElementInScene = MonoBehaviour.FindObjectsByType(uIReplacer.UIElement.GetType(), FindObjectsSortMode.None);

        for (int i = 0; i < uiElementInScene.Length; i++)
        {
            var uiElementInSceneObject = uiElementInScene[i].GameObject();
            MonoBehaviour.DestroyImmediate(uiElementInScene[i]);
            uiElementInSceneObject.AddComponent(uIElement.GetType());
        }

        var interactableUIElementInScene = MonoBehaviour.FindObjectsByType(uIReplacer.InteractableUIElement.GetType(), FindObjectsSortMode.None);

        for (int i = 0; i < interactableUIElementInScene.Length; i++)
        {
            var interactableUIElementInSceneObject = interactableUIElementInScene[i].GameObject();
            MonoBehaviour.DestroyImmediate(interactableUIElementInScene[i]);
            interactableUIElementInSceneObject.AddComponent(interactableUIElement.GetType());
        }
    }
}
