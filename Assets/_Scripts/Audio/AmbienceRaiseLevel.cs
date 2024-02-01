using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceRaiseLevel : MonoBehaviour
{
    public void RaiseAmbienceLevel(float level)
    {
        AmbienceController.instance.SetAmbienceLevel(level);
    }
}
