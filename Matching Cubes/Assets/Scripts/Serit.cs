using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serit : MonoBehaviour
{
    public LineRenderer p1TrailRenderer;
    public LineRenderer p2TrailRenderer;
    private void Awake()
    {

        if(Physics.Raycast(p1TrailRenderer.transform.position,Vector3.down,out RaycastHit hitInfo))
        {
            p1TrailRenderer.SetPosition(0, p1TrailRenderer.transform.position);
            p1TrailRenderer.SetPosition(1, hitInfo.point);

        }

        if (Physics.Raycast(p2TrailRenderer.transform.position, Vector3.down, out RaycastHit hitInfo2))
        {
            p2TrailRenderer.SetPosition(0, p2TrailRenderer.transform.position);
            p2TrailRenderer.SetPosition(1, hitInfo2.point);

        }


    }
}
