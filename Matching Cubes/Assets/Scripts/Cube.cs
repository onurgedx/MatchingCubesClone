using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    private Vector3 firstScale;
    private Vector3 firstLocalPos; 
     delegate void Joining( int index);
     Joining joining;
    public Vector3 currentLocalPosition;

    [SerializeField] private CubeVanishing _cubeVanishing;
    [SerializeField] private CubeAfterCombo _cubeAfterCombo;
    [SerializeField] private CubeReorder _cubeReorder;


    [HideInInspector] public string CubeCode;
    private void Awake()
    {

        joining += FirstJoining;
        joining += Settings;

        firstScale = transform.localScale;
        Vector3 currentLocalPosition = transform.localPosition;
    }


    //public void Down

  
    public void CubeSetting(int index)
    {
        StopAllCoroutines();
        joining(index);
        
    }

    // after combo
    public void SettingAfterCubeCombo(int index)
    {
        StopAllCoroutines();
        _cubeAfterCombo.SettingAfterCubeCombo(index);

    }
    
    public void SettingReorder(int index)
    {
        _cubeReorder.SettingReordering(index);
    }


    
    public void FirstJoining(int index)
    {
        

        StartCoroutine(FirstJoiningIEnumerator(index));
        joining -= FirstJoining;

    }
    public void Settings(int index)
    {
             StartCoroutine(SettingsIEnumerator( index));

    }

    private IEnumerator FirstJoiningIEnumerator(int index)
    {

        transform.parent = CubesController.Instance.transform;
       


        Vector3 CoroutineStartScale = transform.localScale;
        float timeCounter = 0;
        // scale increase
        while (timeCounter<1 )
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime*50, 0, 1);
            transform.localScale = Vector3.Lerp(CoroutineStartScale, CoroutineStartScale * 1.5f, timeCounter);
            transform.localPosition = Vector3.Lerp(transform.localPosition, Vector3.zero, timeCounter);
            yield return null;

        }
        CoroutineStartScale = transform.localScale;
        timeCounter = 0;
        while (timeCounter<1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime * 40,0,1);
            transform.localScale = Vector3.Lerp(CoroutineStartScale, firstScale,timeCounter);
            yield return null;
        }

        

    }
    
    private IEnumerator SettingsIEnumerator(int index)
    {



        Vector3 currentLocalPosition = transform.localPosition;
        Vector3 coroutineFirstPosition = currentLocalPosition;

        float timeCounter = 0;
        while (timeCounter<1)
        {
            timeCounter = Mathf.Clamp(timeCounter+ Time.deltaTime*CubeAndPlayerAvatarCommons.UpSpeed,0,1);
            
            //currentLocalPosition.y = Mathf.Lerp(coroutineFirstPosition.y, index*CubeAndPlayerAvatarCommons.UpAspect,timeCounter);
            currentLocalPosition.y = Mathf.Lerp(currentLocalPosition.y, index*CubeAndPlayerAvatarCommons.UpAspect,timeCounter);

            transform.localPosition = currentLocalPosition;

            yield return null;
        }

        timeCounter = 0;
        coroutineFirstPosition = currentLocalPosition;
        
        while (timeCounter<1)
        {
            timeCounter = Mathf.Clamp(timeCounter + Time.deltaTime *CubeAndPlayerAvatarCommons.DownSpeed, 0, 1);
            currentLocalPosition.y = Mathf.Lerp(coroutineFirstPosition.y, index , timeCounter);

            transform.localPosition = currentLocalPosition;

            yield return null;
        }



        

    }



    public void Vanish() {
        _cubeVanishing.enabled = true;
    }

}
