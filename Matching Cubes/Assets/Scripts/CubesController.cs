using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class CubesController : MonoSingleton<CubesController>
{

    private List<Cube> _cubes=new List<Cube>();

    public PlayerAvatar playerAvatar;

    public int ComboCubeCount = 3;

    public float durationTransferFromVanishToCombo;
    public float durationTransferFromComboToNextIterator;
    public GameObject CubesListGameObject;
    private void AddNewCube(Cube cube)
    {
        
        _cubes.Insert(0,cube);

        SettingAllCubesAndPlayerAvatar();
       CubesOrderCheck();
        
    }
    private void SettingAllCubesAndPlayerAvatar()
    {
        int index = 0;
        foreach (Cube go in _cubes)
        {
            go.CubeSetting(index);
            index++;
        }
        playerAvatar.Setting(index);
    }
    private void SettingAfterComboCube()
    {
        int index = 0;
        foreach(Cube go in _cubes)
        {
            go.SettingAfterCubeCombo(index);
            index++;
        }
        playerAvatar.SettingAfterCubeCombo(index);

        

        
    }

    private void SettingReorder()
    {
        int index = 0;
        foreach(Cube go in _cubes)
        {
            go.SettingReorder(index);
            index++;
        }

    }


    private void CubesOrderCheck()
    {
        StartCoroutine(CubesOrderCheckIEnumerator());
    }
    private IEnumerator CubesOrderCheckIEnumerator()
    {
        int stackCounter = 0;
        string cubeType =_cubes[0].CubeCode ;
        for(int i=0;i<_cubes.Count;i++)
        {
            if(cubeType==_cubes[i].CubeCode)
            {
                stackCounter++;
                if(stackCounter==ComboCubeCount)
                {
                    for(int k=0;k<ComboCubeCount;k++)
                    {
                        _cubes[i - k].Vanish();

                    }

                    for (int k = 0; k < ComboCubeCount; k++)
                    {
                        _cubes.RemoveAt(i-k);
                        
                    }

                    yield return new WaitForSeconds(durationTransferFromVanishToCombo);
                    SettingAfterComboCube();

                    yield return new WaitForSeconds(durationTransferFromComboToNextIterator);
                    i =0;

                    stackCounter = 0;

                }
            }
            else { 
            cubeType = _cubes[i].CubeCode;
            stackCounter = 1;
            }
            
           
        }
        
            

        

    }


    public void ExtractFromCubes(Cube cube)
    {
        Debug.Log("extractfromcubes");
        cube.transform.parent = null;
        _cubes.Remove(cube);
        SettingAfterComboCube();
    }


    private void OnTriggerEnter(Collider collision)
    {


        
        if (collision.gameObject.CompareTag("Cube"))
        {
            
            AddNewCube(collision.gameObject.GetComponent<Cube>());
        }
        else if(collision.gameObject.CompareTag("OrderGate") )
        {
            
            _cubes = _cubes.OrderBy(x => x.CubeCode).ToList();
            SettingReorder();
            CubesOrderCheck();
        }
        else if(collision.gameObject.CompareTag("RandomGate"))
        {
            _cubes = _cubes.OrderBy(x => x.RandomCubeNumber).ToList();
            SettingReorder();
            CubesOrderCheck();
        }
        



    }

    


}
