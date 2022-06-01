using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    
    public float ForwardSpeed;
    public float RightSpeed;

    public float minRight;
    public float maxRight;


    public delegate void PlayerMovement(float rightSlideAmount);
    public PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement += ForwardGo;
        playerMovement += RightGo;
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


}
