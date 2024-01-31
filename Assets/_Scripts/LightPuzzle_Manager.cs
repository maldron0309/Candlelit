using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

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

    public void CheckLightsInOrder()
    {
        for (int i = 1; i < Lights.Count + 1; i++)
        {
            if (Lights[i - 1].enabled)
            {
                if (PuzzleOrder[0].Index == Lights[i - 1].Puzzle_Index)
                {
                    PuzzleOrder[0].endabled = Lights[i - 1].myLight.enabled;
                }
                if (PuzzleOrder.Count > 0 || PuzzleOrder[1].Index == Lights[i - 1].Puzzle_Index && PuzzleOrder[0].endabled)
                {
                    PuzzleOrder[1].endabled = Lights[i - 1].myLight.enabled;
                }
                if (PuzzleOrder.Count > 1 || PuzzleOrder[2].Index == Lights[i - 1].Puzzle_Index && PuzzleOrder[1].endabled)
                {
                    PuzzleOrder[2].endabled = Lights[i - 1].myLight.enabled;
                }
                if (PuzzleOrder.Count > 2 || PuzzleOrder[3].Index == Lights[i - 1].Puzzle_Index && PuzzleOrder[2].endabled)
                {
                    PuzzleOrder[3].endabled = Lights[i - 1].myLight.enabled;
                }
                else
                {
                    TurnOffLights();
                }
            }
        }

    }



    void TurnOffLights()
    {
        foreach (var item in Lights)
        {
            item.myLight.enabled = false;
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