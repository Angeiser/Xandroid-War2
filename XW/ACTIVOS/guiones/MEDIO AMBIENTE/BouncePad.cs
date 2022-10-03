using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
    public float bounceForce;
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player") 
     {
      PlayerController.player.Bounce(bounceForce);
      AudioManager.AM.PlaySFX(0);
     }
    }
}
