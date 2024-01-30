using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] string targetScene; // The name of the scene to load

    private const float delayBeforeSceneChange = 1f;
    private const string playerTag = "Player";

    private FadeEffect fadeEffect;

    private void Start()
    {
        fadeEffect = FindObjectOfType<FadeEffect>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // When the player enters the trigger, start the scene change process
        if (IsPlayer(collision))
        {
            StartCoroutine(ChangeSceneAfterDelay());
        }
    }

    private bool IsPlayer(Collider2D collision)
    {
        // Check if the colliding object is the player
        return collision.gameObject.CompareTag(playerTag);
    }

    private IEnumerator ChangeSceneAfterDelay()
    {
        fadeEffect.StartFadeIn();
        yield return new WaitForSeconds(delayBeforeSceneChange);
        SceneManager.LoadScene(targetScene);
    }
}