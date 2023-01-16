using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public abstract class FilterSelectInteractableObject : MonoBehaviour
    {
        [SerializeField]
        protected ControllerInteractor interactor;

        public XRRInteractable HoverInteractable { get; protected set; }

        public abstract XRRInteractable GetObject(ControllerInteractor interactor);
        public abstract void OnHoverExited(XRRInteractable interactable);

        private void OnValidate()
        {
            this.GetComponent(ref interactor);
        }
    }
}