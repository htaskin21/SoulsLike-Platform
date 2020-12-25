using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGem : MonoBehaviour
{
    [SerializeField] private int _poisonHitTime;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.GetPoisened(_poisonHitTime);
                Destroy(this.gameObject);
            }
        }
    }

}
