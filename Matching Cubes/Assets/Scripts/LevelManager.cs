using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoSingleton<LevelManager>
{
    

    public void NextLevel()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % 3);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

   
    public string LevelName
    {
        get { return SceneManager.GetActiveScene().name; }
    }

}
