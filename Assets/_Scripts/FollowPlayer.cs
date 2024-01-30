using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform lookAt;
    [SerializeField]Vector3 offset;
    [SerializeField]float followSmoothness;
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position,lookAt.position + offset,followSmoothness);
    }
}
