using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("CubesUnderPlayer"))
        {



        }

    }
}
