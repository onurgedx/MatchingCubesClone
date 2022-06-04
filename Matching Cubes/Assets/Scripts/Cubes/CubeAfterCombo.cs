using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAfterCombo : MonoBehaviour
{
    Vector3 currentLocalPosition = Vector3.zero;

    public void SettingAfterCubeCombo(int index)
    {
        StopAllCoroutines();
        StartCoroutine(SettingAfterCubeComboIEnumerator(index));

    }
    private IEnumerator SettingAfterCubeComboIEnumerator(int index)
    {
        yield return new WaitForSeconds(0.075f * index);

        float timeCounter = 0;
        Vector3 coroutineFirstPosition = transform.localPosition;

        while (timeCounter < 1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime * CubeAndPlayerAvatarCommons.DownSpeed, 0, 1);
            currentLocalPosition.y = Mathf.Lerp(coroutineFirstPosition.y, index, timeCounter);

            transform.localPosition = currentLocalPosition;

            yield return null;
        }

    }
}

