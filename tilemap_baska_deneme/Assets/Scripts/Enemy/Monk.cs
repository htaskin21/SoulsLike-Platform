using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : Enemy,IDamageble
{
    public float Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = health;
    }
   
    //public void Damage()
    //{
    //    if (isDead==true)
    //    {
    //        return;
    //    }

    //    health--;
    //    anim.SetTrigger("isHit");
    //    isHit = true;
    //    anim.SetBool("isCombat", true);

    //    if (health < 1)
    //    {
    //        isDead = true;
    //        anim.SetTrigger("isDeath");
    //        GameObject Coin= Instantiate(coinPrefab, transform.position, Quaternion.identity) as GameObject;
    //        Coin.GetComponent<Coin>().coinValue = base.coins;
    //        Destroy(gameObject,0.5f);
    //    }
    //}
}
