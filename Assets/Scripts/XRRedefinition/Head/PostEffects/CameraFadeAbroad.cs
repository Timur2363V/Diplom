using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XRRedefinition
{   
    public class CameraFadeAbroad : MonoBehaviour
    {
        [SerializeField]
        private XRRRayInteractor leftInteractor;
        [SerializeField]
        private XRRRayInteractor rightInteractor;
        [SerializeField]
        private float maxFadeValue = 0.985f;
        [SerializeField]
        private LayerMask collisionMask;
        [SerializeField]
        private SphereCollider playerHeadCollider;
        [SerializeField]
        private CanvasGroup canvasGroup;

        private float minDistanceFadeEffect;
        private List<float> collisionPoints;
        private XRROrigin origin;

        private void Awake()
        {
            origin = XRROrigin.Instance;
            collisionPoints = new List<float>();
            minDistanceFadeEffect = playerHeadCollider.radius;
        }

        private void OnEnable()
        {
            leftInteractor.TeleportAction.InputAction.started += TeleportActivate;
            rightInteractor.TeleportAction.InputAction.started += TeleportActivate;
        }

        private void OnDisable()
        {
            leftInteractor.TeleportAction.InputAction.started -= TeleportActivate;
            rightInteractor.TeleportAction.InputAction.started -= TeleportActivate;
        }

        private void FixedUpdate()
        {
            float nearestPoint = GetNearestPointDistance();
            canvasGroup.alpha = Mathf.Min(maxFadeValue, (1 - (nearestPoint / minDistanceFadeEffect)) * maxFadeValue);
        }

        private void OnTriggerStay(Collider other)
        {
            if (collisionMask.value == 1 << other.gameObject.layer)
            {
                var collisionPoint = Physics.ClosestPoint(playerHeadCollider.transform.position, other, other.transform.position + playerHeadCollider.center, other.transform.rotation);
                collisionPoints.Add(Vector3.Distance(collisionPoint, playerHeadCollider.transform.position));
            }
        }

        private float GetNearestPointDistance()
        {
            var minDistance = minDistanceFadeEffect;

            for (int i = 0; i < collisionPoints.Count; i++)
            {
                minDistance = Mathf.Min(minDistance, collisionPoints[i]);
            }

            collisionPoints.Clear();
            return minDistance;
        }

        private void TeleportActivate(InputAction.CallbackContext context)
        {
            var playerPosition = Vector3.zero;
            var hitPosition = Vector3.zero;
            XRRTeleportController.GetZonePoint(ref playerPosition, ref hitPosition, origin.CameraOrigin.transform.position);
            CheckEnterZone(playerPosition, hitPosition);
        }

        private void CheckEnterZone(Vector3 playerPosition, Vector3 hitPosition)
        {
            if (Vector3.Distance(playerPosition, hitPosition) > Mathf.Epsilon)
            {
                var nextPosition = origin.transform.position + hitPosition - origin.CameraOrigin.transform.position;
                nextPosition.y = hitPosition.y;
                origin.transform.position = nextPosition;
            }
        }

        private void OnValidate()
        {
            this.GetComponentInChildren(ref canvasGroup);
            this.GetComponent(ref playerHeadCollider);
        }
    }
}