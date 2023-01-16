using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition.ActivateInteractableObject
{
    public class AwakeEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent awakeEvent;

        private void Awake()
        {
            awakeEvent.Invoke();
        }
    }
}