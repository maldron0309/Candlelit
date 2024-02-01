using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitBeforeTriggeringEvent : MonoBehaviour
{
    [SerializeField] UnityEvent OnWaitComplete;

    public void WaitBeforeEvent(float waitTime)
    {
        StartCoroutine(HandleWaitingTime(waitTime));
    }

    private IEnumerator HandleWaitingTime(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        OnWaitComplete?.Invoke();
    }
}
