using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float xPosPrevious;

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        ControlPlayer();
    }


    private void ControlPlayer()
    {
        PlayerMovement();

        
            

        
    }

    bool anyTouch
    {
        get { return Input.touchCount > 0; }
    }

    private void PlayerMovement()
    {
        Player.Instance.playerMovement(FingerSlideRightAmount);
    }

    float FingerSlideRightAmount {
        get
        {
            if (anyTouch)
            {
                float xPosViewPort = Camera.main.ScreenToViewportPoint(Input.GetTouch(0).position).x;

                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    xPosPrevious = xPosViewPort;
                }
                else
                {
                    float result = xPosViewPort - xPosPrevious;
                    xPosPrevious = xPosViewPort;
                    return result;
                }

                
                
            }

            return 0f;
        }
    }
    
}
