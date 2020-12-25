using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGroundFire : MonoBehaviour
{
    [SerializeField] private float _burningGroundDamage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageble hit = other.GetComponent<IDamageble>();
            if (hit != null)
            {
                hit.Damage(_burningGroundDamage);
            }
        }
    }
}
