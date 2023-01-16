using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.XRRedefinition
{
    [RequireComponent(typeof(ControllerInteractor))]
    public class FilterDirectInteractableObject : FilterSelectInteractableObject
    {
        protected Dictionary<XRRInteractable, HashSet<Collider>> hoverInteractableColliders = new Dictionary<XRRInteractable, HashSet<Collider>>();

        public void OnHoverEntered(XRRInteractable interactable, Collider collider)
        {
            if (!hoverInteractableColliders.ContainsKey(interactable))
            {
                hoverInteractableColliders.Add(interactable, new HashSet<Collider>());
            }
            else if (!hoverInteractableColliders[interactable].Contains(collider))
            {
                hoverInteractableColliders[interactable].Add(collider);
            }
        }

        public void OnHoverExited(XRRInteractable interactable, Collider collider)
        {
            if (hoverInteractableColliders.ContainsKey(interactable))
            {
                if (hoverInteractableColliders[interactable].Contains(collider))
                {
                    hoverInteractableColliders[interactable].Remove(collider);
                }

                if (hoverInteractableColliders[interactable].Count == 0)
                {
                    hoverInteractableColliders.Remove(interactable);
                }
            }
        }

        public override void OnHoverExited(XRRInteractable interactable)
        {
            if (hoverInteractableColliders.ContainsKey(interactable))
            {
                hoverInteractableColliders.Remove(interactable);
            }
        }

        private XRRInteractable CheckInvokeActionInteractable(Collider collider, Action<XRRInteractable, Collider> action)
        {
            if (collider.attachedRigidbody != null)
            {
                var interactable = collider.attachedRigidbody.GetComponent<XRRInteractable>();

                if (interactable != null)
                {
                    action.Invoke(interactable, collider);
                }

                return interactable;
            }

            return null;
        }

        public override XRRInteractable GetObject(ControllerInteractor interactor)
        {
            var minHoverDistance = float.MaxValue;
            XRRInteractable nearestInteractable = null;

            foreach (var hover in hoverInteractableColliders)
            {
                var hoverDistance = Vector3.Distance(hover.Key.transform.position, interactor.attach.position);

                if (minHoverDistance > hoverDistance)
                {
                    minHoverDistance = hoverDistance;
                    nearestInteractable = hover.Key;
                }
            }

            return nearestInteractable;
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckInvokeActionInteractable(other, OnHoverEntered);
        }

        private void OnTriggerExit(Collider other)
        {
            CheckInvokeActionInteractable(other, OnHoverExited);
        }
    }
}