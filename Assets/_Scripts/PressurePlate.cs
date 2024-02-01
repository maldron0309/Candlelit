using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class PressurePlate : MonoBehaviour
{
    public int Puzzle_Index;
    public bool isStepped;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isStepped)
        {
            isStepped = true;
            
            PlatePuzzle_Manager.Instance.CheckPlatesInOrder(Puzzle_Index);  // ���� �ε��� Ȯ�� �ڵ� �߰�
            FMODOneshot.RequestOneshot("event:/SFX/PuzzleElements/sfx_pressurePlate_step");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isStepped = false;
        }
    }

    public void ResetPlate()
    {
        isStepped = false;
    }
}


