using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CandleLight_ : MonoBehaviour,I_interactable
{
    [SerializeField] UnityEvent OnInteract;

    public void Interact()
    {
        OnInteract?.Invoke();
        gameObject.SetActive(false);
    }
}
