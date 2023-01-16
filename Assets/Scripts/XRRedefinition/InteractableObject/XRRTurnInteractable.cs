using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition.InteractableObject
{
    public class XRRTurnInteractable : XRRInteractable
    {
        [SerializeField]
        private UnityEvent activateEvent;
        [SerializeField]
        private float timeRotation;
        [SerializeField]
        private float[] rotations;

        private int currentTurn;
        private bool isRotating;
        private bool isActivated;

        public override void Selecting(ControllerInteractor component)
        {
            if (isRotating)
            {
                return;
            }

            if (isActivated)
            {
                base.Selecting(component);
            }
            else
            {
                activateEvent.Invoke();
                interactor = component;
            }

            StartCoroutine(Rotate());
        }

        private IEnumerator Rotate()
        {
            isRotating = true;
            var startRotation = transform.rotation.eulerAngles;
            var rotate = rotations[currentTurn];
            var startTime = Time.time;
            var currentRotate = 0f;
            var currentTime = 0f;

            while (currentTime != timeRotation)
            {
                var newRotate = rotate * (currentTime / timeRotation);
                transform.Rotate(new Vector3(newRotate - currentRotate, 0f, 0f));
                currentTime = Mathf.Min(Time.time - startTime, timeRotation);
                currentRotate = newRotate;
                yield return null;
            }

            isRotating = false;
            currentTurn++;

            if (currentTurn >= rotations.Length)
            {
                currentTurn = 0;
            }
        }

        private void OnValidate()
        {
            //isDontRayCastable = true;
        }
    }
}