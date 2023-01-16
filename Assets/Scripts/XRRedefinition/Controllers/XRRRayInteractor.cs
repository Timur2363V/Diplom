using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    [RequireComponent(typeof(FilterRayInteractableObject))]
    public class XRRRayInteractor : ControllerInteractor
    {
        [SerializeField]
        private LineRenderer line;
        [SerializeField]
        private ActionState teleportAction;
        [SerializeField]
        private Color colorHover = Color.green;
        [SerializeField]
        private Color colorDehover = Color.red;

        private const int maxDistanceRaycast = 1000;

        public LineRenderer Line => line;
        public bool LineIsNull => line == null;
        public ActionState TeleportAction => teleportAction;

        private void CreateLine()
        {
            if (LineIsNull)
            {
                return;
            }

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistanceRaycast))
            {
                line.SetPositions(new Vector3[] { transform.position, hit.point });
            }
            else
            {
                line.SetPositions(new Vector3[] { transform.position, transform.position + transform.forward * maxDistanceRaycast });
            }


            if (HoverInteractable != null)
            {
                PaintOverColor(colorHover);
            }
            else
            {
                PaintOverColor(colorDehover);
            }
        }

        public void PaintOverColor(Color paintColor)
        {
            if (!LineIsNull && Line.startColor != paintColor)
            {
                Line.startColor = paintColor;
                Line.endColor = paintColor;
            }
        }

        public override void StartInteractable()
        {
            if (!LineIsNull && !Line.enabled)
            {
                Line.enabled = true;
            }
        }

        public override void StopInteractable()
        {
            if (!LineIsNull && Line.enabled)
            {
                Line.enabled = false;
            }
        }

        protected override void UpdateFrame()
        {
            CreateLine();
            base.UpdateFrame();
        }

        protected override void Enable()
        {
            base.Enable();
            teleportAction.Enable();
        }

        protected override void Disable()
        {
            base.Disable();
            teleportAction.Disable();
        }

        public override void Select(XRRInteractable component)
        {
            if (CheckComponentSelectable(component))
                return;

            base.Select(component);
        }

        public override void Deselect(XRRInteractable component)
        {
            if (CheckComponentSelectable(component))
                return;

            base.Deselect(component);
        }

        private bool CheckComponentSelectable(XRRInteractable component)
        {
            return component is XRRActivateInteractable;
        }
    }
}