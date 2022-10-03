using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public string firstLevel;
    public GameObject panel,continueButton;
    // Start is called before the first frame update
    void Start()
    {
     panel.SetActive(false);
     if (PlayerPrefs.HasKey("CurrentLevel")) 
     {
      if (PlayerPrefs.GetString("CurrentLevel") == "") 
      {
       continueButton.SetActive(false);
      }  
     }
     else 
     {
      continueButton.SetActive(false);   
     }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play() 
    { 
     SceneManager.LoadScene(firstLevel);
     PlayerPrefs.SetString("CurrentLevel", "");
     Time.timeScale = 1f;
    }
    public void Continue() 
    {
     SceneManager.LoadScene(PlayerPrefs.GetString("CurrentLevel"));
    }
    public void Instructions() 
    {
     panel.SetActive(true);
    }
    public void Ready() 
    {
     panel.SetActive(false);
    }
    public void QuitGame()
    {
     Application.Quit();
    }
}
