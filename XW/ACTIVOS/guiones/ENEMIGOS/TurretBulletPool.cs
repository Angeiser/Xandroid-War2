using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletPool : MonoBehaviour
{
    public static TurretBulletPool turret;
    private List<GameObject> bulletObjects = new List<GameObject>();
    public int amountToPool;
    public GameObject bullet;
    private void Awake()
    {
        if (turret == null)
        {
            turret = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
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
