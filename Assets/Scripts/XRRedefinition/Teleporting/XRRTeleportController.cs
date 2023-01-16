using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XRRedefinition
{
    [RequireComponent(typeof(Rigidbody))]
    internal class XRRTeleportController : MonoBehaviour
    {
        [SerializeField]
        private XRRRayInteractor interactor;
        [SerializeField]
        private Color colorCanTeleport = Color.white;
        [SerializeField]
        private Color colorCantTeleport = Color.red;

        private XRROrigin origin;
        private Vector3 pointPlayer;
        private Vector3 zonePointPosition;

        private const float maxDistanceRaycast = 1000f;

        private void Awake()
        {
            origin = XRROrigin.Instance;
        }

        private void Start()
        {
            interactor.TeleportAction.InputAction.canceled += TeleportDeactivate;
        }

        private void OnDestroy()
        {
            interactor.TeleportAction.InputAction.canceled -= TeleportDeactivate;
        }

        private void Update()
        {
            if (!interactor.LineIsNull && !interactor.Line.enabled)
            {
                return;
            }

            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, maxDistanceRaycast))
            {
                GetZonePoint(ref pointPlayer, ref zonePointPosition, hit.point);

                if (Vector3.Distance(zonePointPosition, pointPlayer) <= Mathf.Epsilon)
                {
                    interactor.PaintOverColor(colorCanTeleport);
                }
                else
                {
                    interactor.PaintOverColor(colorCantTeleport);
                }
            }
            else
            {
                interactor.PaintOverColor(colorCantTeleport);
            }
        }

        private void TeleportDeactivate(InputAction.CallbackContext context)
        {
            if (interactor.SelectedInteractable != null)
            {
                return;
            }

            if (Vector3.Distance(zonePointPosition, pointPlayer) <= Mathf.Epsilon)
            {
                Teleport(zonePointPosition);
            }
        }

        public static void GetZonePoint(ref Vector3 position, ref Vector3 point, Vector3 hitPoint)
        {
            position = hitPoint;

            if (NavMesh.SamplePosition(hitPoint, out NavMeshHit myNavHit, 100, -1))
            {
                position.y = myNavHit.position.y;
                point = myNavHit.position;
            }
        }

        private void Teleport(Vector3 point)
        {
            var nextPosition = origin.transform.position + point - origin.CameraOrigin.transform.position;
            nextPosition.y = point.y;
            origin.transform.position = nextPosition;
        }

        private void OnValidate()
        {
            this.GetComponent(ref interactor);
            this.GetComponentInParent(ref origin);
        }
    }
}