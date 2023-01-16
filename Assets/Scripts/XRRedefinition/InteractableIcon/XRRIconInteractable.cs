using UnityEngine;

namespace Assets.Scripts.XRRedefinition.InteractableObject
{
    [RequireComponent(typeof(XRRInteractable))]
    public class XRRIconInteractable : MonoBehaviour
    {
        [SerializeField]
        protected Vector3 addIconPosition;
        [SerializeField]
        protected Animator icon;
        [SerializeField]
        protected XRRInteractable interactable;

        private float startDistance;
        protected XRROrigin origin;
        protected const string iconActiveName = "active", iconHoverName = "hover";

        private Vector3 IconPosition => interactable.Attach.position + addIconPosition;

        protected virtual void Awake()
        {
            startDistance = Vector3.Distance(IconPosition, icon.transform.position);
            origin = XRROrigin.Instance;
            interactable.HoverEvent.AddListener(Hover);
            interactable.DehoverEvent.AddListener(Dehover);
        }

        private void Update()
        {
            LookAtCamera();
        }

        private void LookAtCamera()
        {
            var vectorLookAt = origin.CameraOrigin.transform.position - IconPosition;
            var vectorLookAtMagnitude = vectorLookAt.magnitude;
            vectorLookAt = (vectorLookAt / vectorLookAtMagnitude) * startDistance;
            icon.transform.position = vectorLookAt + IconPosition;
            icon.transform.LookAt(origin.CameraOrigin.transform);
        }

        private void Hover(ControllerInteractor interactor)
        {
            icon.SetBool(iconHoverName, true);
        }

        private void Dehover(ControllerInteractor interactor)
        {
            icon.SetBool(iconHoverName, false);
        }

        public void SetActive(bool isActive)
        {
            icon.SetBool(iconActiveName, isActive);
        }

        private void OnValidate()
        {
            this.GetComponent(ref interactable);
            this.GetComponentInChildren(ref icon);
        }
    }
}