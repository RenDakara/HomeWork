using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void GetAnimation(bool state)
    {
        _animator.SetBool(PlayerAnimatorData.Params.IsRunning, state);
    }
}
