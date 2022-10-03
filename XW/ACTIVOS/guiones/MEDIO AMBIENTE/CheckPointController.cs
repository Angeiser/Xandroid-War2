using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CheckPointController : MonoBehaviour
{
    public GameObject on, off;
    public Transform checkpoint;
    // Start is called before the first frame update
    void Start()
    {
   
    }
    void Update()
    {
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
         GameManager.manager.SetSpawnPoint(transform.position);
         CheckPointController[] allCP = FindObjectsOfType<CheckPointController>();
         for(int i = 0; i < allCP.Length; i++) 
         {
          allCP[i].off.SetActive(true);
          allCP[i].on.SetActive(false);
         }
         off.SetActive(false);
         on.SetActive(true); 
         AudioManager.AM.PlaySFX(1);
        }
    }
}
