using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartEvent : MonoBehaviour
{
    [SerializeField]
    private UnityEvent action;

    private void Start()
    {
        action.Invoke();
    }
}
