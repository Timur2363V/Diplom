using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class XRRActivateInteractable : XRRInteractable
    {
        [SerializeField]
        private Renderer render;
        [SerializeField]
        private Material material;

        public override void Deselecting(ControllerInteractor component)
        {
            if (render.material != material)
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