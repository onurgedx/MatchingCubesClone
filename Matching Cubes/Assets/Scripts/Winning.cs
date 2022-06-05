using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winning : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerAvatar"))
        {
            Debug.Log("You win");
            
            
        }
    }
}
