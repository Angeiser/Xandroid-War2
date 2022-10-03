using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    public string nextLevel;
    public float waitToEndLevel;
    private void OnTriggerEnter(Collider other)
    {
     if (other.gameObject.tag == "Player") 
     {
      GameManager.manager.ending = true;
      StartCoroutine(EndLevel());
      AudioManager.AM.PlayVictoryMusic();
     }
    }
    public IEnumerator EndLevel() 
    {
     PlayerPrefs.SetString("CurrentLevel", nextLevel);
     yield return new WaitForSeconds(waitToEndLevel);
     SceneManager.LoadScene(nextLevel);   
    }
}
