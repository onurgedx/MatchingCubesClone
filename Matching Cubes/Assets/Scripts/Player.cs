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

        
        if(Physics.Raycast(RaycastOriginForRampControl.position,Vector3.down,out RaycastHit hitInfo,1000,1<<8))
        {
            
                
                Vector3 currentPosition = transform.position;
                currentPosition.y = Mathf.Lerp(currentPosition.y, hitInfo.point.y,0.5f);
                transform.position = currentPosition;

            Renderer rend = hitInfo.transform.GetComponent<Renderer>();
            MeshCollider meshCollider = hitInfo.collider as MeshCollider;
            if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                return;
            Texture2D tex = rend.material.mainTexture as Texture2D;
            Vector3 pixelUV = hitInfo.textureCoord;
            pixelUV.x *= tex.width;
            pixelUV.y *= tex.height;

            
            
            tex.SetPixel((int)pixelUV.x, (int)pixelUV.y, Color.black);
            tex.Apply();
            Debug.Log("sds");
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
