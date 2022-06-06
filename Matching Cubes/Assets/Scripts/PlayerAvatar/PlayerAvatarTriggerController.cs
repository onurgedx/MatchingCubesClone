using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatarTriggerController : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Serit") )
        {
            Player.Instance.ForwardSpeed = 0;
            Player.Instance.ForwardSpeedExtra = 0;
            AnimatorManager.Instance.Dying();
            LevelManager.Instance.Invoke("NextLevel", 2);
          
        }
        if ( other.gameObject.CompareTag("ObstacleCube"))
        {
            Player.Instance.ForwardSpeed = 0;
            Player.Instance.ForwardSpeedExtra = 0;
            AnimatorManager.Instance.Dying();
            LevelManager.Instance.Invoke("RestartLevel", 2);
        }

    }
}
