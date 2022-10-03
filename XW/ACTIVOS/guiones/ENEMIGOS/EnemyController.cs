using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyController : MonoBehaviour
{
    public GameObject bullet;
    private bool chasing,wasShot;
    public float distanceToChase = 10f, distanceToLose = 15f, distanceToStop;
    private Vector3 targetPoint, startPoint;
    public NavMeshAgent agent;
    public float keepChasingTime = 5f;
    private float chaseCounter;
    public Transform firePoint;
    public float fireRate, waitBetwennShots = 2f, timeToShoot = 1f;
    private float fireCount, shotWaitCounter, shootTimeCounter;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
     startPoint = gameObject.transform.position;
     shootTimeCounter = timeToShoot;
     shotWaitCounter = waitBetwennShots;
    }

    // Update is called once per frame
    void Update()
    {
     targetPoint = PlayerController.player.transform.position;
     targetPoint.y = transform.position.y;
     if (!chasing) 
     {
      if (Vector3.Distance(transform.position, targetPoint) < distanceToChase) 
      {
      
       chasing = true;
       shootTimeCounter = timeToShoot;
       shotWaitCounter = waitBetwennShots;
      }

      if (chaseCounter > 0) 
      {
       chaseCounter -= Time.deltaTime;
       
       if (chaseCounter <= 0) 
       { 
        agent.destination = startPoint;         
       }
      }
      if (agent.remainingDistance < 0.25f) 
      {
       animator.SetBool("isMoving", false);
      }
      else 
      {
       animator.SetBool("isMoving", true);
      }
     }
     else 
     { 
      transform.LookAt(targetPoint);
      agent.destination = targetPoint;
      if (Vector3.Distance(transform.position, targetPoint) > distanceToLose) 
      { 
       if (!wasShot) 
       { 
        chasing = false;
        chaseCounter = keepChasingTime;        
       }
      }
      else 
      {
       wasShot = false;      
      }
      if (shotWaitCounter > 0) 
      {
       shotWaitCounter -= Time.deltaTime; 
       if (shotWaitCounter<=0)
       {
        shootTimeCounter = timeToShoot;
       } 
       animator.SetBool("isMoving", true);
      }
      else
      {
       if (PlayerController.player.gameObject.activeInHierarchy)
       {
        shootTimeCounter -= Time.deltaTime;
        if (shootTimeCounter>0) 
        {
         fireCount -= Time.deltaTime;
         if (fireCount <= 0) 
         {
          fireCount=fireRate;
          firePoint.LookAt(PlayerController.player.transform.position+new Vector3(0f,0f,0f));
          Vector3 target = PlayerController.player.transform.position - transform.position;
          float angle = Vector3.SignedAngle(target, transform.forward, Vector3.up);
          if (Mathf.Abs(angle) < 30f) 
          {
           GameObject enemy = EnemyBulletPool.enemy.GetBulletObject();
           if (enemy != null)
           {
            enemy.transform.position = firePoint.position;
            enemy.transform.rotation = firePoint.rotation;
            enemy.SetActive(true);
            animator.SetTrigger("fireShot");
           }             
          } 
          else 
          {
           shotWaitCounter = waitBetwennShots;               
          }
         }
         agent.destination = transform.position;
        }
        else
        {
         shotWaitCounter = waitBetwennShots;            
        }    
       }        
      }   
      animator.SetBool("isMoving", true);
     }
    }
    public void GetShot() 
    {
     wasShot = true;
     chasing = true;
    }
}
