using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeVanishing : MonoBehaviour
{
    private MaterialPropertyBlock _materialPropertyBlock=null;
    private MeshRenderer _meshRenderer;
    private  Color firstColor;
    public float vanishDuration = 0.25f;
   
     private void Awake()
    {
        _materialPropertyBlock = new MaterialPropertyBlock();
        _meshRenderer = GetComponent<MeshRenderer>();
     //   _meshRenderer.SetPropertyBlock(_materialPropertyBlock);
        firstColor = _meshRenderer.material.color;
    }
    private void OnEnable()
    {

        StartCoroutine(BeNothing());
    }

    private IEnumerator BeNothing()
    {

        SetColorWithPropertyBlock(Color.white);
        float timeCounter = 0;
        while (timeCounter < vanishDuration)
        {
            timeCounter += Time.deltaTime;

            Color clr = Color.Lerp(Color.white, firstColor, timeCounter);
            SetColorWithPropertyBlock(clr);
            BeSmaller(timeCounter);

            yield return null;

        }
        CanvasManager.Instance.HeartGoesToTopLeftFromCube(transform.position);

        yield return null;
        Destroy(gameObject);
    }


    private void SetColorWithPropertyBlock(Color clr)
    {
        _materialPropertyBlock.SetColor("_Color", clr);
        _meshRenderer.SetPropertyBlock(_materialPropertyBlock);

    }
    private void BeSmaller(float aspect )
    {
        transform.localScale = Vector3.Lerp(CubeAndPlayerAvatarCommons.firstScaleEveryCube*1.3f, Vector3.zero, aspect*4);

    }



}
