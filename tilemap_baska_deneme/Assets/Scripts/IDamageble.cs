using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageble
{
    float Health { get; set; }

    void Damage(float damagePoint);

}
