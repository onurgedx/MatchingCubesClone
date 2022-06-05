using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar :MonoSingleton<PlayerAvatar>
{

    [SerializeField]private AnimatorManager _animator;
    private Vector3 currentLocalPosition ;

    private void Start()
    {
        currentLocalPosition = transform.localPosition;

    }
    


    public void SettingAfterCubeCombo(int index)
    {
        StopAllCoroutines();
        AnimationSetting(index);
        
        StartCoroutine(SettingAfterCubeComboIEnumerator(index));

    }
    private IEnumerator SettingAfterCubeComboIEnumerator(int index)
    {
        yield return new WaitForSeconds(0.075f*index);
        float timeCounter = 0;
        Vector3 coroutineFirstPosition = transform.localPosition;

        while (timeCounter < 1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime * CubeAndPlayerAvatarCommons.DownSpeed, 0, 1);
            currentLocalPosition.y = Mathf.Lerp(coroutineFirstPosition.y, index, timeCounter);

            transform.localPosition = currentLocalPosition;

            yield return null;
        }



        yield return null;


    }

    

    public void Setting(int index)
    {
        StopAllCoroutines();
        AnimationSetting(index);
       


        StartCoroutine(SettingIEnumerator(index));

    }

    private IEnumerator SettingIEnumerator(int index)
    {
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
        //currentLocalPosition.y = index;
      //  transform.localPosition = currentLocalPosition;

        
    }


    public void AnimationSetting(int index)
    {
        if (index == 0)
        {
            _animator.Run();
        }
        else
        {
            _animator.Skate();
        }

    }



}
