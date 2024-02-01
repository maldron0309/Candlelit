using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FMODLoader : MonoBehaviour
{
    [SerializeField] GameObject loadingText;
    [SerializeField] GameObject startButton;
    [SerializeField] string[] banksToLoad;
    [SerializeField] string sceneToLoad;

    private IEnumerator Start()
    {
        loadingText.SetActive(true);
        startButton.SetActive(false);

        foreach(string bank in banksToLoad)
        {
            FMODUnity.RuntimeManager.LoadBank(bank, true);
        }

        while(FMODUnity.RuntimeManager.HaveAllBanksLoaded == false)
        {
            yield return null;
        }

        loadingText.SetActive(false);
        startButton.SetActive(true);
    }

    public void LoadStartingLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
