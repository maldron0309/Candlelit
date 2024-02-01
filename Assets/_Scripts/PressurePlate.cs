using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class PressurePlate : MonoBehaviour
{
    private Light_meUp lightMeUp;
    public bool isStepped;

    private void Start()
    {
        lightMeUp = GetComponent<Light_meUp>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isStepped)
        {
            isStepped = true;
            lightMeUp.Interact();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isStepped = false;
        }
    }
}
