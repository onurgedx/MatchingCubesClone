using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{

   
    

    private void Start()
    {
   
    }
    public void Setting(int index)
    {
        StartCoroutine(SettingIEnumerator(index));

    }

    private IEnumerator SettingIEnumerator(int index)
    {Vector3 currentLocalPosition = transform.localPosition;
        Vector3 CoroutineStartLocalPosition = currentLocalPosition;

        float timeCounter = 0;
        while( timeCounter<1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime * CubeAndPlayerAvatarCommons.UpSpeed, 0, 1);
          //  currentLocalPosition.y = Mathf.Lerp(CoroutineStartLocalPosition.y, index*CubeAndPlayerAvatarCommons.UpAspect, timeCounter);
            currentLocalPosition.y = Mathf.Lerp(currentLocalPosition.y, index*CubeAndPlayerAvatarCommons.UpAspect, timeCounter);
            transform.localPosition = currentLocalPosition;
            yield return null;
        }

         timeCounter = 0;
        CoroutineStartLocalPosition = currentLocalPosition;
        while (timeCounter < 1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime * CubeAndPlayerAvatarCommons.DownSpeed, 0, 1);
            currentLocalPosition.y = Mathf.Lerp(CoroutineStartLocalPosition.y, index , timeCounter);
            transform.localPosition = currentLocalPosition;
            yield return null;
        }
        currentLocalPosition.y = index;
        transform.localPosition = currentLocalPosition;

        yield return null;
    }
}
