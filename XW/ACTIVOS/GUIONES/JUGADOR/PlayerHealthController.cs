using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController health;
    public int maxHealth, currrentHealth;
    private float invinCounter;
    public float invicibleLength;
    void Awake()
    {
     health = this;   
    }
    void Start()
    {
     currrentHealth = maxHealth;
     UIController.UI.healthSlider.maxValue = maxHealth;
     UIController.UI.healthSlider.value = currrentHealth;
     UIController.UI.healthText.text = "HEALTH: " + currrentHealth + "/" + maxHealth;
    }
    // Update is called once per frame
    void Update()
    {
     if (invinCounter > 0) 
     {
      invinCounter -= Time.deltaTime;  
     }   
    }
    public void DamagePlayer(int damageAmount) 
    {
     if (invinCounter <= 0 && !GameManager.manager.ending)
     {
      AudioManager.AM.PlaySFX(7);
      currrentHealth -= damageAmount;
      UIController.UI.ShowDamage();
      if (currrentHealth <= 0) 
      {
       gameObject.SetActive(false);
       currrentHealth = 0;
       GameManager.manager.Respawn();
       AudioManager.AM.PlaySFX(6);
       AudioManager.AM.StopSFX(7);
      }
      invinCounter = invicibleLength;
      UIController.UI.healthSlider.value = currrentHealth;
      UIController.UI.healthText.text = "Health: " + currrentHealth + "/" + maxHealth;
     }
    }
    public void HealPlayer(int healAmount) 
    {
     currrentHealth += healAmount;
     if (currrentHealth > maxHealth) 
     {
      currrentHealth = maxHealth;   
     }
     UIController.UI.healthSlider.value = currrentHealth;
     UIController.UI.healthText.text = "Health: " + currrentHealth + "/" + maxHealth;
    }
}
