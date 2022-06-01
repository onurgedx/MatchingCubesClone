using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{

    // burdaki volatile multithread durumlarinda istenmeyen durumlari(fazladan instanceimiz olmasi gibi) engelliyor
    // T diye belirttigimiz burdan miras alacak classin ismini ifade ediyor 
    private static volatile T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType(typeof(T)) as T;
            }
            return instance;
        }

    }



}