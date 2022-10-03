using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject bullet;
    public float rangeToTarget,timeBetwennShots,rotateSpeed=1f;
    public float shotCounter;
    public Transform gun, firePoint,firePoint2;

    // Start is called before the first frame update
    public void Start()
    {
     shotCounter = timeBetwennShots;
    }

    // Update is called once per frame
    public void Update()
    {
     if (!GameManager.manager.ending) 
     {
      if (Vector3.Distance(transform.position, PlayerController.player.transform.position) < rangeToTarget) 
      {
       gun.LookAt(PlayerController.player.transform.position + new Vector3(0f, 0.2f, 0f));
       shotCounter =- Time.deltaTime;
       if (shotCounter <= 0)
       {
        GameObject turret = TurretBulletPool.turret.GetBulletObject();
        if (turret != null)
        {
         turret.transform.position = firePoint.position;
         turret.transform.rotation = firePoint.rotation;
         turret.SetActive(true);
         shotCounter = timeBetwennShots;
        }
        GameObject turret2 = TurretBulletPool.turret.GetBulletObject();
        if (turret2 != null)
        {
         turret2.transform.position = firePoint2.position;
         turret2.transform.rotation = firePoint2.rotation;
         turret2.SetActive(true);
         shotCounter = timeBetwennShots;
        }
       }
       else 
       {
        gun.rotation = Quaternion.Lerp(gun.rotation, Quaternion.Euler(0f, gun.rotation.eulerAngles.y + 10f, 0f), rotateSpeed * Time.deltaTime);
        shotCounter = timeBetwennShots;
       }
      }        
     }
    }
}
