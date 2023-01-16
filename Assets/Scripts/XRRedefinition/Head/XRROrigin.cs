using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class XRROrigin : MonoSingleton<XRROrigin>
    {
        [SerializeField]
        private Camera cameraOrigin;

        public LayerMask cullingLayer = ~0;

        public Camera CameraOrigin => cameraOrigin;

        private void OnValidate()
        {
            this.GetComponentInChildren(ref cameraOrigin);
        }
    }
}