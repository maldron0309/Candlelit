using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODOneshot : MonoBehaviour
{
    public static void RequestOneshot(string eventPath)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventPath);
    }

    public static void RequestOneshotWithPosition(string eventPath, Vector3 position)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventPath, position);
    }
}
