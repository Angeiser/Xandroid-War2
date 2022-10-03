using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class VictoryScreen : MonoBehaviour
{
    public string mainMenu;
    public float timeBetweenShowing,blackScreenFade;
    public GameObject textBox, returnButton;
    public Image blackScreen;

    void Start()
    {
     textBox.SetActive(false);
     returnButton.SetActive(false);
     StartCoroutine(ShowObjects());
     Cursor.lockState = CursorLockMode.Confined;
     Cursor.visible = true;
    }
    void Update()
    {
     blackScreen.color = new Color(blackScreen.color.r, blackScreen.color.g, blackScreen.color.b, Mathf.MoveTowards(blackScreen.color.a, 0f, blackScreenFade * Time.deltaTime));    
    }
    public void MainMenu() 
    {
     SceneManager.LoadScene(mainMenu);
     Time.timeScale = 1f;
    }
    public IEnumerator ShowObjects() 
    {
     yield return new WaitForSeconds(timeBetweenShowing);
     textBox.SetActive(true);
     yield return new WaitForSeconds(timeBetweenShowing);
     returnButton.SetActive(true);
    }
}
