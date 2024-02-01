using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.Events;

public class LightPuzzle_Manager : MonoBehaviour
{
    public static LightPuzzle_Manager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    public List<Light_meUp> Lights = new List<Light_meUp>();
    public List<puzzle_Order> PuzzleOrder = new List<puzzle_Order>();


    [SerializeField] int currentIndex = 0;
    [SerializeField] int NextIndex = 1;



    [Header("Event")]
    public UnityEvent onComplete;
    public UnityEvent onFailure;


    public void CheckLightsInOrder(int Index)
    {

        currentIndex = Index - 1;

        if (Index == NextIndex)
        {
            NextIndex = Index + 1;
            PuzzleOrder[currentIndex].endabled = true;
        }
        else
        {
            TurnOffLights();
            currentIndex = 0;
            NextIndex = 1;
        }
        if (PuzzleOrder.All(x => x.endabled == true))
        {
            onComplete.Invoke();
        }

    }

    void TurnOffLights()
    {
        onFailure.Invoke();
        print("No");
        foreach (var item in Lights)
        {
            item.myLight.enabled = false;
            item.flameSr.enabled = false;
            item.lightFlicker.enabled = false;
        }
        foreach (var item in PuzzleOrder)
        {
            item.endabled = false;
        }
    }


}



[Serializable]
public class puzzle_Order
{
    public int Index;
    public bool endabled;
}