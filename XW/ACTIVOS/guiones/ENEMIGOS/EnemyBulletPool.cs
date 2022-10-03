using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletPool : MonoBehaviour
{
    public static EnemyBulletPool enemy;
    private List<GameObject> bulletObjects = new List<GameObject>();
    public int amountToPool;
    public GameObject bullet;
    private void Awake()
    {
     if (enemy == null) 
     {
      enemy = this;   
     }
    }
    // Start is called before the first frame update
    void Start()
    {
     for(int i = 0; i < amountToPool; i++) 
     {
      GameObject obj = Instantiate(bullet);
      obj.SetActive(false);
      bulletObjects.Add(obj);      
     }   
    }
    public GameObject GetBulletObject() 
    {
     for (int i = 0; i < amountToPool; i++) 
     {
      if (!bulletObjects[i].activeInHierarchy) 
      {
       return bulletObjects[i];      
      }  
     }
     return null;
    }
}
