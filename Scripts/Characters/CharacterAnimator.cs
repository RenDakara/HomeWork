using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void MakeAnimation(bool state)
    {
        _animator.SetBool(CharacterAnimatorData.Params.IsRunning, state);
    }
}
