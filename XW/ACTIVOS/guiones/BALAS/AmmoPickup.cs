using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    private bool collected;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player" && !collected) 
     {
      PlayerController.player.activateGun.Ammo();
      Destroy(gameObject);
      collected = true;
      AudioManager.AM.PlaySFX(4);
     }
    }
}
