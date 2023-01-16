using UnityEngine.Events;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XRRedefinition
{
    [RequireComponent(typeof(Rigidbody))]
    public class ControllerInteractor : MonoBehaviour, IInteractable<XRRInteractable>
    {
        [SerializeField]
        private ActionState selectAction;
        [SerializeField]
        protected UnityEvent<XRRInteractable> hoverEvent;
        [SerializeField]
        protected UnityEvent<XRRInteractable> dehoverEvent;
        [SerializeField]
        protected UnityEvent<XRRInteractable> selectEvent;
        [SerializeField]
        protected UnityEvent<XRRInteractable> deselectEvent;
        [SerializeField]
        protected Rigidbody rBody;
        [SerializeField]
        private FilterSelectInteractableObject filter;
        [SerializeField]
        private ControllerInteractor anotherInteractor;
        [SerializeField]
        private ActivateDistance activateDistance;

        public Transform attach;

        public UnityEvent<XRRInteractable> HoverEvent => hoverEvent;
        public UnityEvent<XRRInteractable> DehoverEvent => dehoverEvent;
        public UnityEvent<XRRInteractable> SelectEvent => selectEvent;
        public UnityEvent<XRRInteractable> DeselectEvent => deselectEvent;

        public XRRInteractable HoverInteractable { get; protected set; }
        public XRRInteractable SelectedInteractable { get; protected set; }
        public FilterSelectInteractableObject Filter => filter;

        private void Awake()
        {
            if (attach == null)
            {
                attach = transform;
            }
        }

        public virtual void Hover(XRRInteractable component)
        {
            hoverEvent.Invoke(component);
            component.Hover(this);
        }

        public virtual void Dehover(XRRInteractable component)
        {
            dehoverEvent.Invoke(component);
            component.Dehover(this);
        }

        public virtual void Select(XRRInteractable component)
        {
            if (SelectedInteractable != null || (component.Interactor != null && component.Interactor.transform == transform) ||
                anotherInteractor.SelectedInteractable != null)
                return;

            if (component.IsSelected)
            {
                component.Interactor.Deselect(component);
            }

            component.Select(this);

            if (component.IsSelected)
            {
                selectEvent.Invoke(component);
                SelectedInteractable = component;
            }
        }

        public virtual void Deselect(XRRInteractable component)
        {
            if (!component.IsSelected)
                return;

            if (component == SelectedInteractable)
            {
                component.Deselect(this);

                if (!component.IsSelected)
                {
                    filter.OnHoverExited(component);
                    deselectEvent.Invoke(component);
                    SelectedInteractable = null;
                }
            }
            else
            {
                SelectedInteractable = null;
            }
        }

        public void InvokeActionInteractable(XRRInteractable interactable, Action<XRRInteractable> action)
        {
            if (interactable != null)
            {
                action.Invoke(interactable);
            }
        }

        private void OnEnable() => Enable();
        private void OnDisable() => Disable();
        private void Update() => UpdateFrame();

        protected virtual void Enable()
        {
            selectAction.Enable();
            selectAction.InputAction.started += SelectActivated;
            selectAction.InputAction.canceled += SelectDeactivated;
        }

        protected virtual void Disable()
        {
            selectAction.Disable();
            selectAction.InputAction.started -= SelectActivated;
            selectAction.InputAction.canceled -= SelectDeactivated;
        }

        protected virtual void UpdateFrame()
        {
            var interactable = filter.GetObject(this);

            if (SelectedInteractable != null || (interactable != null && !interactable.enabled) || !activateDistance.CheckDistance(interactable, this))
            {
                interactable = null;
            }

            if (interactable == null)
            {
                if (HoverInteractable != null)
                {
                    Dehover(HoverInteractable);
                    HoverInteractable = null;
                }
            }
            else if (HoverInteractable != interactable)
            {
                InvokeActionInteractable(HoverInteractable, Dehover);
                Hover(interactable);
                HoverInteractable = interactable;
            }
        }

        private void SelectActivated(InputAction.CallbackContext context)
        {
            InvokeActionInteractable(HoverInteractable, Select);
        }

        [ContextMenu("Select")]
        public void EditorTestSelect()
        {
            InvokeActionInteractable(HoverInteractable, Select);
        }

        private void SelectDeactivated(InputAction.CallbackContext context)
        {
            InvokeActionInteractable(SelectedInteractable, Deselect);
        }

        public virtual void StartInteractable() { }

        public virtual void StopInteractable() { }

        private void OnValidate()
        {
            this.GetComponent(ref rBody);
            this.GetComponent(ref filter);
            this.GetAnotherComponent(ref anotherInteractor);
            activateDistance = FindObjectOfType<ActivateDistance>();
        }
    }
}