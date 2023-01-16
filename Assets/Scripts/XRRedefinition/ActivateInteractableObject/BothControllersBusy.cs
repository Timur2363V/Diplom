using Assets.Scripts.XRRedefinition.InteractableObject;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition.ActivateInteractableObject
{
    public class BothControllersBusy : MonoBehaviour
    {
        [SerializeField]
        private XRRInteractable[] interactables;
        [SerializeField]
        private XRRIconInteractable[] icons;
        [SerializeField]
        private XRRRayInteractor[] rayInteractors;
        [SerializeField]
        private ControllerInteractor[] directInteractors;

        private const string leftName = "Left", rightName = "Right";
        private bool isControllersBusy;

        private void Update()
        {
            var leftBusy = CheckBusy(rayInteractors[0], directInteractors[0]);
            var rightBusy = CheckBusy(rayInteractors[1], directInteractors[1]);

            if (leftBusy && rightBusy)
            {
                SetActiveInteractables(isControllersBusy, false);
            }
            else
            {
                SetActiveInteractables(!isControllersBusy, true);
            }
        }

        private void SetActiveInteractables(bool isActive, bool enable)
        {
            if (isActive)
                return;

            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].enabled = enable;
            }

            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].SetActive(enable);
            }

            isControllersBusy = !enable;
        }

        private bool CheckBusy(XRRRayInteractor rayInteractor, ControllerInteractor interactor)
        {
            return (rayInteractor != null && rayInteractor.SelectedInteractable != null) ||
                (interactor != null && interactor.SelectedInteractable != null);
        }

        private void OnValidate()
        {
            interactables = FindObjectsOfType<XRRInteractable>();
            icons = FindObjectsOfType<XRRIconInteractable>();
            FindControllers();
        }

        private void FindControllers()
        {
            var rayControllerInteractors = FindObjectsOfType<XRRRayInteractor>();
            var directControllerInteractors = FindObjectsOfType<ControllerInteractor>();

            rayInteractors = new XRRRayInteractor[]
            {
                rayControllerInteractors.FirstOrDefault(x => x.name.Contains(leftName)),
                rayControllerInteractors.FirstOrDefault(x => x.name.Contains(rightName))
            };
            directInteractors = new ControllerInteractor[]
            {
                directControllerInteractors.FirstOrDefault(x => x.name.Contains(leftName)),
                directControllerInteractors.FirstOrDefault(x => x.name.Contains(rightName))
            };
        }

        public void SetActiveInteractables(bool enable)
        {
            for (int i = 0; i < interactables.Length; i++)
            {
                interactables[i].enabled = enable;
            }

            for (int i = 0; i < icons.Length; i++)
            {
                icons[i].SetActive(enable);
            }
        }

        public void SetActiveInteractableFalse(XRRInteractable interactable)
        {
            interactable.enabled = false;
        }

        public void SetActiveInteractableTrue(XRRInteractable interactable)
        {
            interactable.enabled = true;
        }
    }
}