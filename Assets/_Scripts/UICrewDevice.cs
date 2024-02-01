using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UICrewDevice : MonoBehaviour
{
    [SerializeField] TextMeshPro deviceText;

    public void SetText(string text)
    {
        deviceText.text = text;
    }
}
