using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition.InteractableObject
{
    public class XRRTakeCapInteractable : XRRTakeInteractable
    {
        [SerializeField]
        private Transform attachInHead;
        [SerializeField]
        private List<GameObject> triggerObjects;
        [SerializeField]
        private float height = 0f;

        private void OnTriggerEnter(Collider other)
        {
            if (transform.parent != null &&
                !triggerObjects.Contains(transform.parent.gameObject) &&
                triggerObjects.Contains(other.gameObject))
            {
                isEntered = true;
                Interactor.Deselect(this);
                transform.SetParent(Camera.main.transform);
                transform.localPosition = Vector3.zero + (Vector3.up * height);
                transform.localRotation = attachInHead.localRotation;
                rBody.isKinematic = true;
            }
        }
    }
}