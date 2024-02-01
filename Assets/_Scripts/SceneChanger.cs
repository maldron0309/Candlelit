using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger: MonoBehaviour
{
    public Animator animator;

    public float SceneTransition_time = 1f;

    public void LoadNextLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    public void LoadCurrentLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void LoadPreviousLevel()
    {
        StartCoroutine(loadLevel(SceneManager.GetActiveScene().buildIndex -1));
    }

    IEnumerator loadLevel(int levelInt)
    {
        animator.SetTrigger("Start");
        yield return new WaitForSeconds(SceneTransition_time);
        AsyncOperation operation = SceneManager.LoadSceneAsync(levelInt);
        while (!operation.isDone)
        {
            // print(operation.progress);
            yield return null;

        }

    }
}

