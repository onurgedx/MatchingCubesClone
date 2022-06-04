using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{


    private List<GameObject> Tracks = new List<GameObject>();

    public GameObject ObjectToPooling;
    public int poolAmount;
    private void Awake()
    {
        for(int i=0; i < poolAmount; i++)
        {
            GameObject obj = Instantiate(ObjectToPooling,null);
            obj.SetActive(false);
            Tracks.Add(obj);
        }
        
    }

    private void FixedUpdate()
    {
        
        if (CubesController.Instance._cubes.Count > 0  && Player.Instance.playerMovement !=Player.Instance.Flying) { 
        GameObject go = RequestTrack();
        go.GetComponent<Renderer>().material = CubesController.Instance._cubes[0].gameObject.GetComponent<Renderer>().material;
        go.SetActive(true);
        go.transform.position = transform.position;
        }
        
    }

    private GameObject RequestTrack()
    {
        foreach (GameObject obj2 in Tracks)
        {
            if (!obj2.activeInHierarchy)
            {
                
                return obj2;
            }
        }

        GameObject obj = Instantiate(ObjectToPooling, null);
        obj.SetActive(false);
        Tracks.Add(obj);
        return obj;

    }


}
