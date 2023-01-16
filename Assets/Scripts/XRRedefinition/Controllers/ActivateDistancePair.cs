using System;
using UnityEngine;

namespace Assets.Scripts.XRRedefinition
{
    [Serializable]
    public class ActivateDistancePair
    {
        [SerializeField]
        private float distance;
        [SerializeField]
        private InteractableType interactableType;

        public float Distance => distance;
        public InteractableType InteractableType => interactableType;
    }
}