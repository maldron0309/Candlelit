using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerEvent : MonoBehaviour
{
    [SerializeField] bool onTriggerEnterPlaysOnce;
    [SerializeField] bool onTriggerExitPlaysOnce;
    bool onTriggerEnterPlayed = false;
    bool onTriggerExitPlayed = false;
    [SerializeField] UnityEvent OnTriggerEnter;
    [SerializeField] UnityEvent OnTriggerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (onTriggerEnterPlaysOnce)
        {
            if (!onTriggerEnterPlayed)
            {
                OnTriggerEnter?.Invoke();
                onTriggerEnterPlayed = true;
            }
        }
        else
        {
            OnTriggerEnter?.Invoke();
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (onTriggerExitPlaysOnce)
        {
            if (!onTriggerExitPlayed)
            {
                OnTriggerExit?.Invoke();
                onTriggerExitPlayed = true;
            }
        }
        else
        {
            OnTriggerExit?.Invoke();
        }
    }
}
