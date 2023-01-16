using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.XRRedefinition.ResetManager
{
    public class ResettingApplication : MonoBehaviour
    {
        [SerializeField]
        private ActionState inputAction;
        [SerializeField]
        private float clampedTimeRestart = 3f;
        
        private Coroutine timerReset;

        private void StartTimer(InputAction.CallbackContext callback)
        {
            if (timerReset == null)
            {
                timerReset = StartCoroutine(StartCheckReset());
            }
        }

        private void StopTimer(InputAction.CallbackContext callback)
        {
            if (timerReset != null)
            {
                StopCoroutine(timerReset);
                timerReset = null;
            }
        }

        private IEnumerator StartCheckReset()
        {
            yield return new WaitForSeconds(clampedTimeRestart);
            //SceneLoader.LoadStartScene();
        }

        private void Awake()
        {
            if (!inputAction.IsNull)
            {
                inputAction.Enable();
                inputAction.InputAction.started += StartTimer;
                inputAction.InputAction.canceled += StopTimer;
            }
        }

        private void OnDestroy()
        {
            if (!inputAction.IsNull)
            {
                inputAction.Disable();
                StopTimer(default);
                inputAction.InputAction.started -= StartTimer;
                inputAction.InputAction.canceled -= StopTimer;
            }
        }
    }
}