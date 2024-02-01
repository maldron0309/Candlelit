using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] string grassPath;
    [SerializeField] string stonePath;

    string currentPath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name.Contains("Grass"))
        {
            currentPath = grassPath;
        }
        else if (collision.name.Contains("Stone"))
        {
            currentPath = stonePath;
        }
    }

    public void RequestFootstep()
    {
        FMODOneshot.RequestOneshot(currentPath);
    }
}
