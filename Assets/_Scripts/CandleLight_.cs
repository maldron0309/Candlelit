using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleLight_ : MonoBehaviour,I_interactable
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
