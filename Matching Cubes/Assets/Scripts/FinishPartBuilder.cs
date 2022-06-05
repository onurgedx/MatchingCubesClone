using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishPartBuilder : MonoBehaviour
{
    public GameObject Serit;
    public int seritAmount;
    public GameObject winning;

    private void Awake()
    {

        for(int i =seritAmount;i>0;i--)
        {

            Vector3 point = new Vector3(transform.position.x, transform.position.y + i, transform.position.z + (seritAmount - i)*4);

            GameObject serit = Instantiate(Serit, point, transform.rotation, transform);



        }        

        winning.transform.position = new Vector3(transform.position.x, transform.position.y , transform.position.z + (seritAmount +1 ) * 4);


    }
}
