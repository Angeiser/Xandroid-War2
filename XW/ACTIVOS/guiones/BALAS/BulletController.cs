using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float moveSpeed,lifetime;
    public Rigidbody RB;
    public GameObject impactEffect;
    public int damage;
    public bool damageEnemy, damagePlayer;
    // Start is called before the first frame update
    void Start()
    {
     lifetime = 5f;   
    }

    // Update is called once per frame
    void Update()
    {
     RB.velocity = transform.forward * moveSpeed;
     lifetime -= Time.deltaTime;
     if (lifetime <= 0) 
     {
      gameObject.SetActive(false);
      lifetime = 5f;
     }
    }
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Enemy"&& damageEnemy) 
     {
      other.gameObject.GetComponent<EnemyHealthController>().DamageEnemy(damage); 
     }
     if (other.gameObject.tag == "Turret" && damageEnemy)
     {
      other.gameObject.GetComponent<TurretHealthController>().DamageEnemy(damage);
     }
     if (other.gameObject.tag == "HeadShot" && damageEnemy)
     {
      other.transform.parent.GetComponent<EnemyHealthController>().DamageEnemy(damage * 2);
     }
     if (other.gameObject.tag == "Player" && damagePlayer)
     {
      PlayerHealthController.health.DamagePlayer(damage);
     }
     gameObject.SetActive(false);
     Instantiate(impactEffect, transform.position+(transform.forward*(-moveSpeed*Time.deltaTime)), transform.rotation);
    }
}
