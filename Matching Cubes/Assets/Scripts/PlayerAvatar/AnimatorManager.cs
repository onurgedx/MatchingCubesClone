using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoSingleton<AnimatorManager>
{
    [SerializeField]private Animator _animator;


    public void Skate()
    {
        _animator.ResetTrigger("fly");
        _animator.ResetTrigger("run");
        _animator.SetTrigger("skate");

        
    }
    public void Fly()
    {
        
        _animator.ResetTrigger("skate");
        _animator.ResetTrigger("run");
        _animator.SetTrigger("fly");

    }

    public void Run()
    {
        _animator.ResetTrigger("fly");
        _animator.ResetTrigger("skate");
        _animator.SetTrigger("run");
        
    }

    public void Dying()
    {
        _animator.ResetTrigger("fly");
        _animator.ResetTrigger("run");
        _animator.ResetTrigger("skate");
        _animator.SetTrigger("dying");
    }

   

}
