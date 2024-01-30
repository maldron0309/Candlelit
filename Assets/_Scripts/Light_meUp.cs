using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class Light_meUp : MonoBehaviour
{
    public bool isLighted = false;
    public int Puzzle_Index;
    [SerializeField]Light2D myLight;


    void Start(){
        InvokeRepeating(nameof(CheckMyLight),1f,0.25f);
    }
    void CheckMyLight(){
        if(!isLighted){
            myLight.enabled = false;

        }else{
            myLight.enabled = true;
            
        }
        LightPuzzle_Manager.Instance.CheckLightsInOrder();
        
    }
}
