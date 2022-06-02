using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeReorder : MonoBehaviour
{
    Vector3 currentLocalPosition = Vector3.zero;

    public void SettingReordering(int index)
    {
            currentLocalPosition.y = index;

            transform.localPosition = currentLocalPosition;

    }
    
}
