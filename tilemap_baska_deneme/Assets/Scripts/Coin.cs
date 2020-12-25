using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _pickUpSound;
    [Range(0f, 1f)] [SerializeField] private float _pickUpSoundVolume;
    
    public int coinValue;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_pickUpSound, Camera.main.transform.position, _pickUpSoundVolume);
                player.AddCoins(coinValue);
                Destroy(this.gameObject);
            }
        }   
    }
}
