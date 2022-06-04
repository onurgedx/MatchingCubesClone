using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoSingleton<AnimatorManager>
{
    [SerializeField]private Animator _animator;


    public void Skate()
    { _animator.SetTrigger("skate");

        
    }
    public void Fly()
    {
        _animator.SetTrigger("fly");

    }

    public void Run()
    {
        _animator.SetTrigger("run");
    }


}
