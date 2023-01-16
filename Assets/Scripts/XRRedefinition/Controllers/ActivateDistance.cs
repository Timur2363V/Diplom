using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    public class ActivateDistance : MonoBehaviour
    {
        [SerializeField]
        private ActivateDistancePair[] activateDistancePairs;

        private Dictionary<InteractableType, float> activateDistanceDictionary;

        private void Awake()
        {
            activateDistanceDictionary = new Dictionary<InteractableType, float>();

            for (int i = 0; i < activateDistancePairs.Length; i++)
            {
                activateDistanceDictionary.Add(activateDistancePairs[i].InteractableType, activateDistancePairs[i].Distance);
            }
        }

        public bool CheckDistance(XRRInteractable interactable, ControllerInteractor interactor)
        {
            if (interactable == null)
                return false;

            return Vector3.Distance(interactable.Attach.position, interactor.attach.position) <= activateDistanceDictionary[interactable.InteractableType];
        }
    }
}