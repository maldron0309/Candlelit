using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAfterLanding : MonoBehaviour
{
    [SerializeField]SceneChanger changer;
    public void TriggerAnimationComplete(){
        changer.LoadNextLevel();
    }
}
