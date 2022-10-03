using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool pool;
    public int amountToPool,amountToPool2,amountToPool3,amountToPool4,amountToPool5,amountToPool6,amountToPool7;
    public GameObject bullet, bullet2,bullet3,bullet4,bullet5,bullet6,bullet7;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private List<GameObject> pooledObjects2 = new List<GameObject>();
    private List<GameObject> pooledObjects3 = new List<GameObject>();
    private List<GameObject> pooledObjects4 = new List<GameObject>();
    private List<GameObject> pooledObjects5 = new List<GameObject>();
    private List<GameObject> pooledObjects6 = new List<GameObject>();
    private List<GameObject> pooledObjects7 = new List<GameObject>();
    private void Awake()
    {
     if (pool == null) 
     {
      pool = this;   
     }    
    }
    // Start is called before the first frame update
    void Start()
    {
     for(int i = 0; i < amountToPool; i++) 
     {
      GameObject obj = Instantiate(bullet);
      obj.SetActive(false);
      pooledObjects.Add(obj);
     }
     for (int i = 0; i < amountToPool2; i++)
     {
      GameObject obj = Instantiate(bullet2);
      obj.SetActive(false);
      pooledObjects2.Add(obj);
     }
     for (int i = 0; i < amountToPool3; i++)
     {
      GameObject obj = Instantiate(bullet3);
      obj.SetActive(false);
      pooledObjects3.Add(obj);
     }
     for (int i = 0; i < amountToPool4; i++)
     {
      GameObject obj = Instantiate(bullet4);
      obj.SetActive(false);
      pooledObjects4.Add(obj);
     }
     for (int i = 0; i < amountToPool5; i++)
     {
      GameObject obj = Instantiate(bullet5);
      obj.SetActive(false);
      pooledObjects5.Add(obj);
     }
     for (int i = 0; i < amountToPool6; i++)
     {
      GameObject obj = Instantiate(bullet6);
      obj.SetActive(false);
      pooledObjects6.Add(obj);
     }
     for (int i = 0; i < amountToPool7; i++)
     {
      GameObject obj = Instantiate(bullet7);
      obj.SetActive(false);
      pooledObjects7.Add(obj);
     }
    }
    public GameObject GetPooledObject() 
    {
     for(int i = 0; i < pooledObjects.Count; i++) 
     {
      if(!pooledObjects[i].activeInHierarchy) 
      {
       return pooledObjects[i];      
      }   
     }
     return null;  
    }
    public GameObject GetPooledObject2()
    { 
     for (int i = 0; i < pooledObjects2.Count; i++)
     {
      if (!pooledObjects2[i].activeInHierarchy)
      {
       return pooledObjects2[i];
      }
     }
     return null;
    }
    public GameObject GetPooledObject3()
    {
     for (int i = 0; i < pooledObjects3.Count; i++)
     {
      if (!pooledObjects3[i].activeInHierarchy)
      {
       return pooledObjects3[i];
      }
     }
     return null;
    }
    public GameObject GetPooledObject4()
    {
     for (int i = 0; i < pooledObjects4.Count; i++)
     {
      if (!pooledObjects4[i].activeInHierarchy)
      {
       return pooledObjects4[i];
      }
     }
     return null;
    }
    public GameObject GetPooledObject5()
    {
     for (int i = 0; i < pooledObjects5.Count; i++)
     {
      if (!pooledObjects5[i].activeInHierarchy)
      {
       return pooledObjects5[i];
      }
     }
     return null;
    }
    public GameObject GetPooledObject6()
    {
     for (int i = 0; i < pooledObjects6.Count; i++)
     {
      if (!pooledObjects6[i].activeInHierarchy)
      {
       return pooledObjects6[i];
      }
     }
     return null;
    }
    public GameObject GetPooledObject7()
    {
     for (int i = 0; i < pooledObjects7.Count; i++)
     {
      if (!pooledObjects7[i].activeInHierarchy)
      {
       return pooledObjects7[i];
      }
     }
     return null;
    }
}
