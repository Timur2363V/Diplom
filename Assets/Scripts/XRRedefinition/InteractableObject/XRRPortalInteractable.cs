using UnityEngine;

namespace Assets.Scripts.XRRedefinition.InteractableObject
{
    public class XRRPortalInteractable : XRRInteractable
    {
        [SerializeField]
        private string sceneName;

        public override InteractableType InteractableType => InteractableType.Portal;

        public override void Deselecting(ControllerInteractor component)
        {
            base.Deselecting(component);
            Teleport();
        }

        private void Teleport()
        {
            //SceneLoader.LoadScene(sceneName);
        }
    }
}