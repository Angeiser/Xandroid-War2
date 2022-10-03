using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public bool canAutoFire;
    public float fireRate,fireCounter,zoomAmount;
    public int currentAmmo,pickupAmount;
    public string gunName,bulletName;
    // Update is called once per frame
    void Update()
    {
     if (fireCounter > 0) 
     {
      fireCounter -= Time.deltaTime;   
     }   
    }
    public void Ammo()
    {
     currentAmmo += pickupAmount;
     UIController.UI.ammoText.text = "AMMO: " + currentAmmo;
    }
}
