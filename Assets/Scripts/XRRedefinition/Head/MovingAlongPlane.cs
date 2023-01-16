using UnityEngine;

namespace Assets.Scripts.XRRedefinition.Head
{
    public class MovingAlongPlane : MonoBehaviour
    {
        [SerializeField]
        private LayerMask layerMovingPlane;

        private XRROrigin origin;

        private const float maxDistanceRaycast = 10f;
        private float maxDistanceRaycastHeight = 5f;

        private void Awake()
        {
            origin = XRROrigin.Instance;
        }

        private void Update()
        {
            var currentPositionOrigin = origin.transform.position;

            if (Physics.Raycast(transform.position + (transform.up * maxDistanceRaycastHeight), -transform.up, out RaycastHit hit, maxDistanceRaycast, layerMovingPlane))
            {
                currentPositionOrigin.y = hit.point.y;
            }

            origin.transform.position = currentPositionOrigin;
        }
    }
}