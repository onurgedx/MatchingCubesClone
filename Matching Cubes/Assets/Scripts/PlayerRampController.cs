using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRampController : MonoBehaviour
{
   
    [SerializeField]Player _player;
    private IEnumerator PositionRampCenterIEnumerator(float centerx)
    {
        float timeCounter = 0;
        Vector3 currentPosition = transform.position;
        while (timeCounter < 1)
        {
            timeCounter += Time.deltaTime * 10;
            currentPosition.x = Mathf.Lerp(currentPosition.x, centerx, timeCounter);
            transform.position = currentPosition;
            yield return null;
        }


    }
    private void PositionRampCenter(float centerx)
    {
        StartCoroutine(PositionRampCenterIEnumerator(centerx));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RampEnterance"))
        {
            PositionRampCenter(other.transform.position.x);
            _player.EntryRamp();
        }
        else if(other.gameObject.CompareTag("RampExit"))
        {
            _player.ExitRamp();
        }
    }
}
