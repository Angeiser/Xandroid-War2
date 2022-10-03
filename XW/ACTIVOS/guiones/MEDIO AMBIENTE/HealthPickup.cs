using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healAmount;
    public bool isColleted;
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player"&& !isColleted) 
     {
      PlayerHealthController.health.HealPlayer(healAmount);
      Destroy(gameObject);
      isColleted = true;
      AudioManager.AM.PlaySFX(5);
     }   
    }
}
