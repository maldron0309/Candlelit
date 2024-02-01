using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenTitleAnimation : MonoBehaviour
{
    [SerializeField] float endingPosition;
    [SerializeField] float animationTime;
    [SerializeField] LeanTweenType easeType;

    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalX(gameObject, endingPosition, animationTime).setEase(easeType).setLoopPingPong();

    }
}
