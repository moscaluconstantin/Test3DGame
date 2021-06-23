using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
     public string animTrigName;
     public ThirdPersonPlayerMovement player;

     private void OnEnable()
     {
          player.weaponAnimTrig = animTrigName;
     }
     private void OnDisable()
     {
          player.weaponAnimTrig = "";
     }
}
