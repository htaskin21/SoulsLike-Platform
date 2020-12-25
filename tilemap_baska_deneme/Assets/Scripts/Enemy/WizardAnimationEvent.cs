using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardAnimationEvent : MonoBehaviour
{
    private Wizard _wizard;

    void Start()
    {
        _wizard = transform.parent.GetComponent<Wizard>();
    }

    public void Fire()
    {
        _wizard.Attack();
    }
}
