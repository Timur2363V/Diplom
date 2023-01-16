using System;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition
{
    [RequireComponent(typeof(Rigidbody))]
    public class XRRInteractable : MonoBehaviour, IInteractable<ControllerInteractor>
    {
        [SerializeField]
        protected bool isDontRayCastable = false;
        [SerializeField]
        private Transform attach;
        [SerializeField]
        private UnityEvent<ControllerInteractor> hoverEvent;
        [SerializeField]
        private UnityEvent<ControllerInteractor> dehoverEvent;
        [SerializeField]
        private UnityEvent<ControllerInteractor> selectEvent;
        [SerializeField]
        private UnityEvent<ControllerInteractor> deselectEvent;
        [SerializeField]
        protected Rigidbody rBody;
        [SerializeField]
        private InteractableType interactableType = InteractableType.TakeObject;

        protected ControllerInteractor interactor;

        public UnityEvent<ControllerInteractor> HoverEvent => hoverEvent;
        public UnityEvent<ControllerInteractor> DehoverEvent => dehoverEvent;
        public UnityEvent<ControllerInteractor> SelectEvent => selectEvent;
        public UnityEvent<ControllerInteractor> DeselectEvent => deselectEvent;
        public bool IsSelected => interactor != null;
        public Transform Attach => attach == null ? transform : attach;
        public ControllerInteractor Interactor => interactor;
        public Rigidbody RBody => rBody;
        public virtual InteractableType InteractableType => interactableType;

        public void Select(ControllerInteractor component)
        {
            CheckRayCastable(Selecting, component);
        }

        public virtual void Selecting(ControllerInteractor component)
        {
            selectEvent.Invoke(component);
            interactor = component;
        }

        public void Deselect(ControllerInteractor component)
        {
            CheckRayCastable(Deselecting, component);
        }

        public virtual void Deselecting(ControllerInteractor component)
        {
            deselectEvent.Invoke(component);
            interactor = null;
        }

        public void Hover(ControllerInteractor component)
        {
            CheckRayCastable(hoverEvent.Invoke, component);
        }

        public void Dehover(ControllerInteractor component)
        {
            CheckRayCastable(dehoverEvent.Invoke, component);
        }

        public void CheckRayCastable(Action<ControllerInteractor> action, ControllerInteractor interactor)
        {
            if (isDontRayCastable && interactor is XRRRayInteractor)
                return;

            action.Invoke(interactor);
        }

        private void OnValidate()
        {
            this.GetComponent(ref rBody);
        }

        private void OnEnable()
        {
            
        }
    }
}