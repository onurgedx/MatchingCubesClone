using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeVanishing : MonoBehaviour
{
    private MaterialPropertyBlock _materialPropertyBlock=null;
    private MeshRenderer _meshRenderer;
    private  Color firstColor;
     private void Awake()
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
        _meshRenderer = GetComponent<MeshRenderer>();
     //   _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        firstColor = _meshRenderer.material.color;
    }
    private void OnEnable()
    {
        _materialPropertyBlock.SetColor("_Color", Color.white);
        _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        // bir seyler olucak iste
        

    }
}
