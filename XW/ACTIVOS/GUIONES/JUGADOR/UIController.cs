using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public static UIController UI;
    public Slider healthSlider;
    public Text healthText,ammoText;
    public Image blackScreen,damageEffect,blackScreen2;
    public float fadeSpeed,damageAlpha,damageFadeSpeed,fadeSpeed2;
    public bool fadeToBlack, fadeFromBlack;
    public GameObject pauseScreen;
    // Start is called before the first frame update
    void Awake()
    {
     UI = this;   
    }
    void Start()
    {
     pauseScreen.SetActive(false);    
    }
    // Update is called once per frame
    void Update()
    {
     if (damageEffect.color.a != 0) 
     {
      damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, Mathf.MoveTowards(damageEffect.color.a,0f,damageFadeSpeed*Time.deltaTime));
     }
     if (fadeToBlack) 
     {
      blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 1f, fadeSpeed * Time.deltaTime));
      if (blackScreen.color.a == 1f) 
      {
       fadeToBlack = false;      
      }
     }
     if (fadeFromBlack)
     {
      blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
      if (blackScreen.color.a == 0f)
      {
       fadeFromBlack = false;
      }
     }
     if (!GameManager.manager.ending) 
     {
      blackScreen2.color = new Color(blackScreen2.color.r, blackScreen2.color.g, blackScreen2.color.b, Mathf.MoveTowards(blackScreen2.color.a, 0f, fadeSpeed2 * Time.deltaTime));  
     }
     else 
     {
            blackScreen2.color = new Color(blackScreen2.color.r, blackScreen2.color.g, blackScreen2.color.b, Mathf.MoveTowards(blackScreen2.color.a, 1f, fadeSpeed2 * Time.deltaTime));
        }
    }
    public void ShowDamage() 
    {
     damageEffect.color = new Color(damageEffect.color.r, damageEffect.color.g, damageEffect.color.b, damageAlpha);
    }
}
