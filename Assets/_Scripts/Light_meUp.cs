using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Light_meUp : MonoBehaviour, I_interactable
{
    public int Puzzle_Index;
    public Light2D myLight;


    public void Interact()
    {
        SwitchLight();
        LightPuzzle_Manager.Instance.CheckLightsInOrder(Puzzle_Index);
    }
    void SwitchLight()
    {
        myLight.enabled = !myLight.enabled;
    }
}
public interface I_interactable
{
   public void Interact();
}

