using UnityEngine;
using Assets.Scripts.XRRedefinition;
using System.Collections.Generic;
using System.Linq;

[RequireComponent(typeof(Collider))]
public class RespawnInteractiveItems : MonoBehaviour
{
    [SerializeField]
    private List<XRRTakeInteractable> interactableObjects;
    [SerializeField]
    private Dictionary<XRRTakeInteractable, Vector3> startPositionInteractableObjects;
    [SerializeField]
    private Dictionary<XRRTakeInteractable, Quaternion> startRotationInteractableObjects;

    private void Awake()
    {
        GetPositionAndRotationInteractableObjects();
    }

    private void GetPositionAndRotationInteractableObjects()
    {
        startPositionInteractableObjects = new Dictionary<XRRTakeInteractable, Vector3>();
        startRotationInteractableObjects = new Dictionary<XRRTakeInteractable, Quaternion>();

        for (int i = 0; i < interactableObjects.Count; i++)
        {
            startPositionInteractableObjects.Add(interactableObjects[i], interactableObjects[i].transform.position);
            startRotationInteractableObjects.Add(interactableObjects[i], interactableObjects[i].transform.rotation);
        }
    }

    private void OnValidate()
    {
        FindInteractableObjects();
    }

    private void FindInteractableObjects()
    {
        if (interactableObjects == null || interactableObjects.Count == 0)
        {
            var components = FindObjectsOfType<XRRTakeInteractable>();
            interactableObjects = components.ToList();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider != null &&
            !collision.collider.attachedRigidbody.isKinematic &&
            !collision.collider.isTrigger &&
            collision.collider.attachedRigidbody.TryGetComponent(out XRRTakeInteractable interactable))
        {
            interactable.transform.position = startPositionInteractableObjects[interactable];
            interactable.transform.rotation = startRotationInteractableObjects[interactable];
            collision.collider.attachedRigidbody.isKinematic = true;
        }
    }
}
