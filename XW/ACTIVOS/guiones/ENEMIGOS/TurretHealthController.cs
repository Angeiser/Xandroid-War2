using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealthController : MonoBehaviour
{
    public int currentLife;
    public void DamageEnemy(int DamageAmount)
    {
        currentLife -= DamageAmount;
        if (currentLife <= 0)
        {
            Destroy(gameObject);
            AudioManager.AM.PlaySFX(2);
        }
    }
}
