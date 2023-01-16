using UnityEngine;

namespace Assets.Scripts.XRRedefinition.InteractableObject
{
    public class XRRTakeAndActivateInteractable : XRRTakeInteractable
    {
        [SerializeField]
        private XRRTakeInteractable interactable;
        [SerializeField]
        private Renderer render;
        [SerializeField]
        private Material material;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out XRRTakeInteractable takeInteractable) &&
                takeInteractable == interactable && render.material != material)
            {
                render.material = material;
            }
        }

        private void OnValidate()
        {
            this.GetComponent(ref render);
        }
    }
}