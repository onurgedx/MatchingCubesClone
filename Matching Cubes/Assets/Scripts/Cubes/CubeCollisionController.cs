using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCollisionController : MonoBehaviour
{

    public Cube cube;




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ObstacleCube"))
        {
            if (Player.Instance.ForwardSpeedExtra > 0)
            {
                collision.gameObject.GetComponent<Rigidbody>().AddForce((transform.position - collision.transform.position)*10);
            }
            else
            {
                CubesController.Instance.ExtractFromCubes(cube);

            }
            
        }
    }




}
