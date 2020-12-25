using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _playerAnimator;
    void Start()
    {
        _playerAnimator = GetComponentInChildren<Animator>();
    }

    public void Run(bool run)
    {
        _playerAnimator.SetBool("isRunning", run);
    }

    public void Jump(bool jump)
    {
        _playerAnimator.SetBool("isJumping", jump);
    }

    public void Attack()
    {
        _playerAnimator.SetTrigger("isAttacking");
    }

    public void Death()
    {
        _playerAnimator.SetTrigger("isDeath");
    }

    public void Hit()
    {
        _playerAnimator.SetTrigger("isHit");
    }
}
