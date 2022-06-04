using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{

    private float ForwardSpeedExtra;
    public float ForwardSpeed;
    public float RightSpeed;

    public float minRight;
    public float maxRight;



    public Transform RaycastOriginForRampControl;

    public delegate void PlayerMovement(float rightSlideAmount);
    public PlayerMovement playerMovement;

    private void Awake()
    {


        

        playerMovement += ForwardGo;
        playerMovement += RightGo;
        playerMovement += AlwaysOnPlaneMovement;
    }
    public void ForwardGo(float rightSlideAmount)
    {
        transform.position += Vector3.forward * Time.deltaTime * (ForwardSpeed+ForwardSpeedExtra);

    }
    public void RightGo(float rightSlideAmount)
    {
     
        Vector3 currentPosition = transform.position;
        currentPosition.x += RightSpeed * rightSlideAmount;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minRight, maxRight);
        transform.position = currentPosition;

    }
    
    public void AlwaysOnPlaneMovement(float righSlideAmount)
    {

        RaycastHit hitInfo;

        if(Physics.Raycast(RaycastOriginForRampControl.position,Vector3.down,out hitInfo,1000,1<<8))
        {
            
            
                
                Vector3 currentPosition = transform.position;
                currentPosition.y = Mathf.Lerp(currentPosition.y, hitInfo.point.y,0.25f);
                transform.position = currentPosition;


            
        }
        else if(Physics.Raycast(RaycastOriginForRampControl.position, Vector3.down, out hitInfo, 1000, 1 << 11))
        {
            Fly(hitInfo.transform.gameObject.GetComponent<FlyRamp>().Finish.position);
        }
       
        

    }

  
    public void EntryRamp()
    {
       
        
        playerMovement = AlwaysOnPlaneMovement;
        playerMovement += ForwardGo;
       

    }


    public void ExitRamp()
    {
        OnPlatform();
    
    }

    public void OnPlatform()
    {
        playerMovement = AlwaysOnPlaneMovement;
        playerMovement += ForwardGo;
        playerMovement += RightGo;
    }
    public void Flying(float rightSlideAmount)
    {

    }
    
   
    public void Fly(Vector3 FinishPoint)
    {

        StartCoroutine(FlyIEnumerator(FinishPoint,1));

    }

    private IEnumerator FlyIEnumerator(Vector3 FinishPoint,float AspectJumpHeight)
    {
        playerMovement =Flying;

        Vector3 StartPoint = transform.position;
        
        Vector3 directionToDestionationFromfirstPos = FinishPoint -StartPoint;
        float timeCounter =0;



        while (timeCounter < 1) {


            timeCounter = Mathf.Clamp01(timeCounter + Time.deltaTime);

            transform.position = StartPoint * Mathf.Pow((1 - timeCounter), 3)
                                      + (StartPoint + directionToDestionationFromfirstPos * 0.25f + Vector3.up * 4 * AspectJumpHeight) * Mathf.Pow(1 - timeCounter, 2) * timeCounter * 3
                                      + 3 * (1 - timeCounter) * timeCounter * timeCounter * (FinishPoint - directionToDestionationFromfirstPos * 0.25f + Vector3.up * 6 * AspectJumpHeight)
                                      + timeCounter * timeCounter * timeCounter *FinishPoint;
            
            yield return null;
        }

        ExtraForwardSpeedDown(0);

        
        yield return null;
        OnPlatform();

    }




    public void ExtraForwardSpeedUp(float newAmount)
    {
        ForwardSpeedExtra = newAmount;

    }
    public void ExtraForwardSpeedDown(float newAmount)
    {
        ForwardSpeedExtra = newAmount;

    }

}
