using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODOneshot : MonoBehaviour
{
    public static void RequestOneshot(string eventPath)
    {
        FMODUnity.RuntimeManager.PlayOneShot(eventPath);
    }
}
