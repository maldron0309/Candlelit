using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlatePuzzle_Manager : MonoBehaviour
{

    public Color PressedColor;
    public Color UnPressedColor;
    public static PlatePuzzle_Manager Instance;

    public List<PressurePlate> Plates = new List<PressurePlate>();
    public List<PuzzleOrder> PlateOrder = new List<PuzzleOrder>();

    [SerializeField] int currentIndex = 0;
    [SerializeField] int nextIndex = 1;

    [Header("Event")]
    public UnityEvent onComplete;
    public UnityEvent onFailure;



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

    public void CheckPlatesInOrder(int index)
    {
        if (index == nextIndex)
        {
            currentIndex = index - 1;
            PlateOrder[currentIndex].enabled = true;
            nextIndex = index + 1;
        }
        else
        {
            ResetPlates();
        }


        foreach (var item in Plates)
        {
            if (item.isStepped)
            {
                item.GetComponent<SpriteRenderer>().color = PressedColor;
            }
        }
        if (PlateOrder.All(x => x.enabled == true))
        {
            onComplete.Invoke();
            FMODOneshot.RequestOneshot("event:/SFX/PuzzleElements/sfx_puzzle_Complete");
        }

        Debug.Log($"Plate {index} stepped. Current state: {PlateOrder[currentIndex].enabled}");
    }


    void ResetPlates()
    {
        onFailure.Invoke();
        Debug.Log("NO");
        foreach (var item in PlateOrder)
        {
            item.enabled = false;
        }
        foreach (var plate in Plates)
        {
            plate.ResetPlate();
            plate.GetComponent<SpriteRenderer>().color = UnPressedColor;
        }
        currentIndex = 0;
        nextIndex = 1;
    }

}

[Serializable]
public class PuzzleOrder
{
    public int index;
    public bool enabled;
}

