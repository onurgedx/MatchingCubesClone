using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSleeper : MonoBehaviour
{
    private void OnEnable()
    {
        Invoke("sleep", 2);
    }

    private void sleep()
    {
        gameObject.SetActive(false);
    }
}
