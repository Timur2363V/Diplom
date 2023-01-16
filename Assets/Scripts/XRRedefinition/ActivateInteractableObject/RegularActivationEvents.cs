using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.XRRedefinition.ActivateInteractableObject
{
    public class RegularActivationEvents : XRRInteractable
    {
        [SerializeField]
        private UnityEvent awakeEvent;
        [SerializeField]
        private UnityEvent firstActivate;
        [SerializeField]
        private UnityEvent[] activateEvents;
        [SerializeField]
        private int currentActivateEvent = 0;

        private void Awake()
        {
            awakeEvent.Invoke();
        }

        public override void Deselecting(ControllerInteractor component)
        {
            base.Deselecting(component);
            activateEvents[currentActivateEvent].Invoke();
            currentActivateEvent++;
            if (currentActivateEvent >= activateEvents.Length)
            {
                currentActivateEvent = 0;
            }
        }

        [ContextMenu("Activate")]
        public void Activate()
        {
            if (currentActivateEvent == -1)
            {
                firstActivate.Invoke();
                currentActivateEvent++;
            }
            else
            {
                activateEvents[currentActivateEvent].Invoke();
                currentActivateEvent++;

                if (currentActivateEvent >= activateEvents.Length)
                {
                    currentActivateEvent = 0;
                }
            }
        }
    }
}