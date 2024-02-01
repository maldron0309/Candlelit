using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] Light2D targetLight;
    [SerializeField] float minIntensity;
    [SerializeField] float maxIntensity;
    [SerializeField] float minFlickerSpeed;
    [SerializeField] float maxFlickerSpeed;

    [SerializeField] bool playsSound;
    [SerializeField] float lightThreshold;
    [SerializeField] string soundPath;

    private void OnEnable()
    {
        float targetIntensity = Random.Range(minIntensity, maxIntensity);
        float targetFlicker = Random.Range(minFlickerSpeed, maxFlickerSpeed);

        StartCoroutine(FlickerLight(targetIntensity, targetFlicker));
    }

    private IEnumerator FlickerLight(float targetIntensity, float targetDuration)
    {
        float currentTime = 0;
        float startingIntensity = targetLight.falloffIntensity;

        while(currentTime < targetDuration)
        {
            currentTime += Time.deltaTime;
            targetLight.intensity = Mathf.Lerp(startingIntensity, targetIntensity, currentTime / targetDuration);
            yield return null;
        }

        if (playsSound && targetLight.intensity >= lightThreshold) FMODOneshot.RequestOneshotWithPosition(soundPath, transform.position);

        float newTargetIntensity = Random.Range(minIntensity, maxIntensity);
        float targetFlicker = Random.Range(minFlickerSpeed, maxFlickerSpeed);

        StartCoroutine(FlickerLight(newTargetIntensity, targetFlicker));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }
}
