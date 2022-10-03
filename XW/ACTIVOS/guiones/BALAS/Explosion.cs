using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public int damage;
    public bool damageEnemy, damagePlayer;
    private void OnTriggerEnter(Collider other)
    {
     AudioManager.AM.PlaySFX(2);
     if (other.gameObject.tag == "Enemy" && damageEnemy)
     {
      other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage);
     }
     if (other.gameObject.tag == "HeadShot" && damageEnemy)
     {
      other.transform.parent.GetComponent<EnemyHealthController>().DamageEnemy(damage * 2);
     }
     if (other.gameObject.tag == "Player" && damagePlayer)
     {
      PlayerHealthController.health.DamagePlayer(damage);
     } 
     Destroy(gameObject);
    }
}
