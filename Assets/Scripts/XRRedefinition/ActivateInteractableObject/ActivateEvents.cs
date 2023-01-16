using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition.ActivateInteractableObject
{
    public class ActivateEvents : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent awakeEvent;
        [SerializeField]
        private UnityEvent activateEvent;
        [SerializeField]
        private UnityEvent deactivateEvent;
        [SerializeField]
        private float timeDeactivated = 30f;
        [SerializeField]
        private List<GameObject> collisionObjects;

        private bool isActive;

        private void Awake()
        {
            awakeEvent.Invoke();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!isActive && collisionObjects.Contains(other.gameObject))
            {
                activateEvent.Invoke();
                isActive = true;
                StartCoroutine(Activate());
            }
        }

        private IEnumerator Activate()
        {
            var startTime = Time.time;

            while (Time.time - startTime < timeDeactivated)
            {
                yield return new WaitForEndOfFrame();
            }

            deactivateEvent.Invoke();
            isActive = false;
        }
    }
}