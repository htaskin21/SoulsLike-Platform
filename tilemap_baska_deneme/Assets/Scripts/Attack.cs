using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private AudioClip _attackSound;
    [SerializeField] [Range(0, 1)] float _attackSoundVolume = 0.4f;
    [SerializeField] private float _damagePoint;

    private bool _canDamage = true;
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageble hit = other.GetComponent<IDamageble>();

        if (hit != null)
        {
            if (_canDamage == true)
            {
                AudioSource.PlayClipAtPoint(_attackSound, Camera.main.transform.position, _attackSoundVolume);
                hit.Damage(_damagePoint);
                _canDamage = false;
                StartCoroutine(ResetDamage());
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    IEnumerator ResetDamage()
    {
        yield return new WaitForSeconds(0.5f);
        _canDamage = true;
    }
}
