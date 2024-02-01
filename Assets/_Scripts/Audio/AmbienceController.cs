using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbienceController : MonoBehaviour
{
    public static AmbienceController instance;
    [SerializeField] string ambienceEventPath;

    FMOD.Studio.EventInstance ambienceEvent;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            transform.SetParent(null);
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Start()
    {
        while (!FMODUnity.RuntimeManager.HaveAllBanksLoaded)
        {
            yield return null;
        }

        ambienceEvent = FMODUnity.RuntimeManager.CreateInstance(ambienceEventPath);
        ambienceEvent.start();
    }

    public void SetAmbienceLevel(float level)
    {
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Level", level);
    }

    public void StopAmbience()
    {
        ambienceEvent.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }
}
