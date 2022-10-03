using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string theGun,bullet;
    private bool collected;
    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player" && !collected)
     {
      PlayerController.player.AddGun(theGun);
      PlayerController.player.AddBullet(bullet);
      Destroy(gameObject);
      collected = true;
      AudioManager.AM.PlaySFX(3);
     }
    }
}
