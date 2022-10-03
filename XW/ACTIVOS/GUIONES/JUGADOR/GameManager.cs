using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager manager;
    public float waitAfterDying = 2f;
    private Vector3 respawnPosition;
    public bool ending;
    private void Awake()
    {
     manager = this;
    }
    // Start is called before the first frame update
    void Start()
    {
     Cursor.lockState = CursorLockMode.Locked;
     Cursor.visible = false;
     respawnPosition = PlayerController.player.transform.position;
    }
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape)) 
     {
      Pause();   
     }     
    }
    public void Respawn() 
    {
     StartCoroutine(RespawnWaiter());
    }
    public IEnumerator RespawnWaiter() 
    { 
     PlayerController.player.gameObject.SetActive(false);
     UIController.UI.fadeToBlack = true;
     yield return new WaitForSeconds(waitAfterDying);
     UIController.UI.fadeFromBlack = true;
     PlayerController.player.transform.position = respawnPosition;
     PlayerController.player.gameObject.SetActive(true);
     PlayerHealthController.health.currrentHealth = PlayerHealthController.health.maxHealth;
     UIController.UI.healthText.text = "Health: " + PlayerHealthController.health.currrentHealth + "/" + PlayerHealthController.health.maxHealth;
     UIController.UI.healthSlider.maxValue = PlayerHealthController.health.maxHealth;
     UIController.UI.healthSlider.value = PlayerHealthController.health.currrentHealth;
    }
    public void SetSpawnPoint( Vector3 newSpawnPoint) 
    {
     respawnPosition = newSpawnPoint;
    }
    public void Pause() 
    {
     if (UIController.UI.pauseScreen.activeInHierarchy) 
     {
      UIController.UI.pauseScreen.SetActive(false);
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      Time.timeScale = 1f;
      PlayerController.player.footstepSlow.Play();
      PlayerController.player.footstepFast.Play();
     }
     else 
     {  
      UIController.UI.pauseScreen.SetActive(true);
      Cursor.lockState = CursorLockMode.Confined;
      Cursor.visible = true;
      Time.timeScale = 0f; 
      PlayerController.player.footstepSlow.Stop();
      PlayerController.player.footstepFast.Stop();
     }
    }
}
