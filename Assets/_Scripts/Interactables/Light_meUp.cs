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
    public SpriteRenderer flameSr;
    public LightFlicker lightFlicker;

    private void Start()
    {
        flameSr.enabled = false;
    }

    public void Interact()
    {
        SwitchLight();
        LightPuzzle_Manager.Instance.CheckLightsInOrder(Puzzle_Index);
    }

    void SwitchLight()
    {
        myLight.enabled = !myLight.enabled;
        flameSr.enabled = myLight.enabled;
        lightFlicker.enabled = myLight.enabled;
        if (myLight.enabled == true) FMODOneshot.RequestOneshot("event:/SFX/PuzzleElements/sfx_torch_on");
    }
}
public interface I_interactable
{
   public void Interact();
}

