using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class XRRTakeInteractable : XRRInteractable
    {
        [SerializeField]
        private GameObject activateObject;
        [SerializeField]
        private Collider[] colliders;

        protected bool isEntered;

        private void Awake()
        {
            SetCollidersTrigger(false);
        }

        public override void Selecting(ControllerInteractor component)
        {
            isEntered = false;
            base.Selecting(component);
            SetAttachPoint(component.attach);
            SetCollidersTrigger(true);
            rBody.isKinematic = true;
            component.StopInteractable();

            if (activateObject != null)
            {
                activateObject.SetActive(false);
            }
        }

        public override void Deselecting(ControllerInteractor component)
        {
            if (isEntered)
            {
                SetCollidersTrigger(false);
                transform.SetParent(null, true);
                rBody.isKinematic = false;
                component.StartInteractable();
                base.Deselecting(component);

                if (activateObject != null)
                {
                    activateObject.SetActive(true);
                }
            }

            isEntered = !isEntered;
        }

        public void SetAttachPoint(Transform attach)
        {
            SetToParent(attach);
            var nextPosition = Attach.position - transform.position;
            transform.position -= nextPosition;
            transform.rotation *= Attach.localRotation;
        }

        public void SetToParent(Transform attach)
        {
            transform.SetParent(attach);
            transform.position = attach.position;
            transform.rotation = attach.rotation;
        }

        private void SetCollidersTrigger(bool isTrigger)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                colliders[i].isTrigger = isTrigger;
            }
        }

        private void OnValidate()
        {
            this.GetComponent(ref rBody);
            this.GetComponents(ref colliders);
        }
    }
}