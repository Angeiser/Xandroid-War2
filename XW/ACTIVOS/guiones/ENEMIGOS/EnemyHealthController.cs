using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public int currentLife;
    public EnemyController enemy;
    public void DamageEnemy(int DamageAmount)
    {
     currentLife-=DamageAmount;
     if (enemy != null) 
     {
      enemy.GetShot();  
     }
     if (currentLife <= 0) 
     {
      Destroy(gameObject);
      AudioManager.AM.PlaySFX(2);
     }
    }
}
