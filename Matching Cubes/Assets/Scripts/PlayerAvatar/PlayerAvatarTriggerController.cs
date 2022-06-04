using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarTriggerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Serit"))
        {
            Debug.Log("dead");
        }
    }
}
