using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioClip _deathsound;
    [SerializeField] [Range(0, 1)] float _deathSoundVolume = 0.4f;

    [SerializeField] private AudioClip _playerHitSound;
    [SerializeField] [Range(0, 1)] float _playerHitSoundVolume = 0.4f;

    public void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(_deathsound, Camera.main.transform.position, _deathSoundVolume);
    }

    public void PlayHitSound()
    {
        AudioSource.PlayClipAtPoint(_playerHitSound, Camera.main.transform.position, _playerHitSoundVolume);
    }
}
