using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableTriggerEvent : MonoBehaviour
{
    [SerializeField] UnityEvent OnEnableEvents;

    private void OnEnable()
    {

        OnEnableEvents?.Invoke();
    }
}
