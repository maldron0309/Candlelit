using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODOneshotMonoBehaviour : MonoBehaviour
{
    public void RequestFmodOneshot(string eventPath)
    {
        FMODOneshot.RequestOneshot(eventPath);
    }
}
