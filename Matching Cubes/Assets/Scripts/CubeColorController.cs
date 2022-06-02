using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorController : MonoBehaviour
{


    public Material CubeMaterial;
    
    [HideInInspector] public string CubeCode;
    private void OnValidate()
    {
        GetComponent<MeshRenderer>().material = CubeMaterial;
        CubeCode = CubeMaterial.name;
        GetComponent<Cube>().CubeCode = CubeCode;
        
    }

}
