using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAnimationEvent : MonoBehaviour
{
    private Ghost _ghost;
    
    void Start()
    {
        _ghost = transform.parent.GetComponent<Ghost>();   
    }

    // Update is called once per frame
    public void Fire()
    {
        _ghost.Attack();
    }
}
