using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    
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
        transform.position += Vector3.forward * Time.deltaTime * ForwardSpeed;

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

        
        if(Physics.Raycast(RaycastOriginForRampControl.position,Vector3.down,out RaycastHit hitInfo))
        {
            
                
                Vector3 currentPosition = transform.position;
                currentPosition.y = Mathf.Lerp(currentPosition.y, hitInfo.point.y,0.5f);
                transform.position = currentPosition;
            
        }

    }

  
    public void EntryRamp()
    {
       
        
        playerMovement = AlwaysOnPlaneMovement;
        playerMovement += ForwardGo;
       

    }

    public void ExitRamp()
    {
        playerMovement = AlwaysOnPlaneMovement;
        playerMovement += ForwardGo;
        playerMovement += RightGo;
        
    }
    


}
