using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpeedUpTriggerController : MonoBehaviour
{
   public  float ExtraSpeedUpAmount;
    public  float ExtraSpeedDownAmount;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("SpeedUp"))
        {        
            Player.Instance.ExtraForwardSpeedUp(ExtraSpeedUpAmount);
        }

    }


    
}
