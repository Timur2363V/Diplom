using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class Events : MonoBehaviour
    {
        private XRROrigin origin;

        private void Awake()
        {
            origin = XRROrigin.Instance;
        }

        public void ActivateComponent(Behaviour component)
        {
            component.enabled = true;
        }

        public void DeactivateComponent(Behaviour component)
        {
            component.enabled = false;
        }

        public void LookAtCamera(Transform component)
        {
            component.LookAt(origin.CameraOrigin.transform);
        }
    }
}