using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.Scripts.XRRedefinition
{
    [Serializable]
    public class ActionState
    {
        [SerializeField]
        protected InputActionReference action;

        public InputAction InputAction => action.action;

        public bool IsNull => action == null;

        public void Enable()
        {
            action.action.Enable();
        }

        public void Disable()
        {
            action.action.Disable();
        }
    }
}