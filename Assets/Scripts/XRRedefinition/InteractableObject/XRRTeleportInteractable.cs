using System.Linq;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition.InteractableObject
{
    public class XRRTeleportInteractable : XRRInteractable
    {
        [SerializeField] private GameObject[] objectsToActivate;
        [SerializeField] private GameObject[] objectsToDeactivate;

        public override InteractableType InteractableType => InteractableType.Teleport;

        public override void Deselecting(ControllerInteractor component)
        {
            if (component.Filter.GetObject(component) != null)
            {
                Teleport(Attach);
                base.Deselecting(component);
            }
            interactor = null;
        }

        public void Teleport(Transform teleport)
        {
            var origin = XRROrigin.Instance;
            var nextPosition = origin.transform.position + teleport.position - origin.CameraOrigin.transform.position;
            nextPosition.y = teleport.position.y;
            origin.transform.position = nextPosition;

            for (int i = 0; i < objectsToDeactivate.Length; i++)
            {
                objectsToDeactivate[i].SetActive(false);
            }

            for (int i = 0; i < objectsToActivate.Length; i++)
            {
                objectsToActivate[i].SetActive(true);
            }
        }

        private void OnValidate()
        {
            if (objectsToActivate == null || objectsToActivate.Length == 0)
            {
                GetActivateObjects();
            }
        }

        private void GetActivateObjects()
        {
            var teleports = FindObjectsOfType<XRRTeleportInteractable>().Where(x => x != this).Select(x => x.gameObject);
            objectsToActivate = teleports.ToArray();
            objectsToDeactivate = new GameObject[] { gameObject };
        }
    }
}