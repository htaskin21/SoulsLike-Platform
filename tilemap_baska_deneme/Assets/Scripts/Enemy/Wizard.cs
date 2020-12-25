using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wizard : Enemy,IDamageble
{
    public float Health { get; set; }

    public GameObject fireEffect;

    //public void Damage()
    //{
    //    if (isDead == true)
    //    {
    //        return;
    //    }

    //    health--;

    //    if (health < 1)
    //    {
    //        isDead = true;
    //        anim.SetTrigger("isDeath");
    //        GameObject Coin = Instantiate(coinPrefab, transform.position, Quaternion.identity) as GameObject;
    //        Coin.GetComponent<Coin>().coinValue = base.coins;
    //        Destroy(gameObject, 0.5f);
    //    }
    //}

    public void Attack()
    {
        Instantiate(fireEffect, transform.position, Quaternion.identity);
    }

    public override void Update()
    {
        if (player != null)
        {
            Movement();
        }
        else
        {
            return;
        }
    }

    public override void Movement()
    {
        Vector2 direction = player.transform.localPosition - transform.localPosition;
        if (Mathf.Abs(direction.x) < 5f)
        {
            anim.SetBool("isCombat", true);
        }
        else if (Mathf.Abs(direction.x) > 5f)
        {
            anim.SetBool("isCombat", false);
        }
        
        
        if (direction.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
        }     
    }

   
}
