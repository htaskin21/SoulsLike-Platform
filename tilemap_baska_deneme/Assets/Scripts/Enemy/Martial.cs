using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Martial : MonoBehaviour
{
    public GameObject dialogCanvas;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void TriggerAttackAnimation()
    {
        _animator.SetBool("isCombat 0",true);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogCanvas.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogCanvas.SetActive(false);           
        }
    }
}
