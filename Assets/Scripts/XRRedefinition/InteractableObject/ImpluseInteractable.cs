using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class ImpluseInteractable : MonoBehaviour
    {
        [SerializeField]
        private XRRTakeInteractable interactable;
        [SerializeField]
        private float speed = 3f;

        private List<Vector3> positions = new List<Vector3>();

        private const int countPositions = 10;

        private void Start()
        {
            interactable.DeselectEvent.AddListener(AddImpluse);
        }

        private void Update()
        {
            while (positions.Count >= countPositions)
            {
                positions.Remove(positions.First());
            }

            positions.Add(transform.position);
        }

        private void OnValidate()
        {
            this.GetComponent(ref interactable);
        }

        private void AddImpluse(ControllerInteractor interactor)
        {
            interactable.RBody.AddForce((positions.Last() - positions.First()) * speed, ForceMode.Impulse);
        }
    }
}