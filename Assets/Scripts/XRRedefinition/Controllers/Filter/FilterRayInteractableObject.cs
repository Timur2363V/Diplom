using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class FilterRayInteractableObject : FilterSelectInteractableObject
    {
        private const int maxDistanceRaycast = 1000;

        public override void OnHoverExited(XRRInteractable interactable)
        {
            if (interactable == HoverInteractable)
            {
                interactor.Dehover(interactable);
                HoverInteractable = null;
            }
        }

        public override XRRInteractable GetObject(ControllerInteractor interactor)
        {
            return HoverInteractable;
        }

        private void Update()
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistanceRaycast, XRROrigin.Instance.cullingLayer) && hit.collider != null)
            {
                if (hit.collider.TryGetComponent(out XRRInteractable colliderInteractableComponent))
                {
                    HoverInteractable = colliderInteractableComponent;
                }
                else
                {
                    HoverInteractable = null;
                }
            }
            else
            {
                HoverInteractable = null;
            }
        }
    }
}