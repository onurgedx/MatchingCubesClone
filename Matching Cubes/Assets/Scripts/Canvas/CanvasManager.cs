using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoSingleton<CanvasManager>
{
    [SerializeField] private Text textHeart;
    [SerializeField] private GameObject HeartImage;
    private int GainedHeartCount=0;

    public Text textLevel;

    private void Awake()
    {
        textLevel.text = LevelManager.Instance.LevelName;
        
    }

    public void HeartGoesToTopLeftFromCube(Vector3 startPos)
    {
        StartCoroutine(HeartGoesToTopLeftFromCubeIEnumerator(startPos));
    }


    private IEnumerator HeartGoesToTopLeftFromCubeIEnumerator(Vector3 startPos)
    {

        GameObject obj = HeartPoolingForCanvas.Instance.RequestHeart();
        obj.transform.position = startPos;
        
        float timeCounter = 0;
        while(timeCounter<1)
        {
            timeCounter += Time.deltaTime;
            obj.transform.position = Vector3.Lerp(startPos, HeartImage.transform.position, timeCounter);
            yield return null;
        }

        GainedHeartCount++;
        textHeart.text = GainedHeartCount.ToString();

        obj.SetActive(false);
        yield return null;


    }


}
