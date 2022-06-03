using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPoolingForCanvas : MonoSingleton<HeartPoolingForCanvas>
{
    public GameObject ObjectToPool;
    public int AmountToPool = 10;
    private List<GameObject> pooledObjects = new List<GameObject>();
    private void Awake()
    {

        for(int i=0;i<AmountToPool;i++)
        {
            GameObject obj = Instantiate(ObjectToPool,transform);
                obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        
    }

    public GameObject RequestHeart()
    {

        foreach(GameObject go in pooledObjects )
        {
            if (!go.activeInHierarchy)
            {
                
                go.SetActive(true);
                return go;
            }

        }

        GameObject obj = Instantiate(ObjectToPool);
        obj.SetActive(true);
        pooledObjects.Add(obj);
        return obj;

    }

}
