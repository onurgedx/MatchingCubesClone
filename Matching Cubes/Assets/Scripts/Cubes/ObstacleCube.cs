using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCube : MonoBehaviour
{
    Collider _collider;
    private void Awake()
    {
        _collider = GetComponent<Collider>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
         if(collision.transform.gameObject.CompareTag("CubeGained"))
        {
            gameObject.layer = 8;
            CubesController.Instance.ExtractFromCubes(collision.gameObject.GetComponent<Cube>());
//            _collider.enabled = false;
        }
    }
    
}
