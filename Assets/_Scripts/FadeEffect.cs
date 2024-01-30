using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEffect : MonoBehaviour
{
    [SerializeField] private float fadeDuration; // The duration of the fade effect

    private bool isFadingIn = false; 
    private bool isFadingOut = false; 
    
    [SerializeField] private CanvasGroup canvasGroup; // The CanvasGroup component to apply the fade effect

    private void Update()
    {
        HandleFadeIn();
        HandleFadeOut();
    }

    private void HandleFadeIn()
    {
        if (isFadingIn && canvasGroup.alpha < 1f)
        {
            canvasGroup.alpha += fadeDuration * Time.deltaTime;

            if (canvasGroup.alpha >= 1f)
            {
                isFadingIn = false;
            }
        }
    }

    private void HandleFadeOut()
    {
        if (isFadingOut && canvasGroup.alpha > 0f)
        {
            canvasGroup.alpha -= fadeDuration * Time.deltaTime;

            if (canvasGroup.alpha <= 0f)
            {
                isFadingOut = false;
            }
        }
    }

    public void StartFadeIn()
    {
        isFadingIn = true;
    }

    public void StartFadeOut()
    {
        isFadingOut = true;
    }
}