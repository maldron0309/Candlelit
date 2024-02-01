
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scrolling_Texture : MonoBehaviour
{
    [SerializeField]RawImage IMG;
    [SerializeField]Vector2 ScrollDir;

    void Update(){
        IMG.uvRect = new Rect(IMG.uvRect.position + ScrollDir * Time.deltaTime,IMG.uvRect.size);
    }

}
