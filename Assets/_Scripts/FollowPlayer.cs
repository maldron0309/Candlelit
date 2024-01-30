using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform lookAt;
    [SerializeField]Vector3 offset;


    [Range(0.75f,2.5f)]
    [SerializeField]float followSmoothness;
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,lookAt.position + offset,followSmoothness * Time.fixedDeltaTime);
    }
}
