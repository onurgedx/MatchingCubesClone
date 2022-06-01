using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesController : MonoSingleton<CubesController>
{

    private List<Cube> _cubes=new List<Cube>();

    public PlayerAvatar playerAvatar;

   

    private void AddNewCube(Cube cube)
    {
        
        _cubes.Insert(0,cube);

        int index = 0;
        foreach(Cube go in _cubes)
        { 
            go.CubeSetting(index);
            index++;
        }
        playerAvatar.Setting(index);
        CubesOrderCheck();

    }

    private void CubesOrderCheck()
    {
        int stackCounter = 0;
        string cubeType =_cubes[0].CubeCode ;
        for(int i=0;i<_cubes.Count;i++)
        {
            if(cubeType==_cubes[i].CubeCode)
            {
                stackCounter++;
                if(stackCounter==3)
                {
                    _cubes[i].Vanish();
                    _cubes[i - 1].Vanish();
                    _cubes[i - 2].Vanish();
                   
                    
                    break;

                }
            }
            
            
           
        }
        
            

        

    }


    private void OnTriggerEnter(Collider collision)
    {


        
        if (collision.gameObject.CompareTag("Cube"))
        {
            
            AddNewCube(collision.gameObject.GetComponent<Cube>());
        }
    }

    


}
