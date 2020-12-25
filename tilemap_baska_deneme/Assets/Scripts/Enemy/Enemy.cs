using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    [SerializeField] protected int coins;

    public GameObject coinPrefab;

    [SerializeField] protected Vector3 pointA, pointB;


    protected Vector3 currentTarget;
    protected bool isHit = false;
    protected bool isDead = false;

    protected Animator anim;
    protected SpriteRenderer sprite;
    protected PlayerMovement player;

    [SerializeField] private AudioClip _deathsound;
    [SerializeField] [Range(0, 1)] float _deathSoundVolume = 0.4f;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }

    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (player !=null)
        {
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && anim.GetBool("isCombat") == false)
            {
                return;
            }
            if (isDead == false)
            {
                Movement();
            }
        }
        else
        {
            return;
        }
       
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA)
        {
            currentTarget = pointB;
            anim.SetTrigger("isIdle");
        }
        else if (transform.position == pointB)
        {
            currentTarget = pointA;
            anim.SetTrigger("isIdle");
        }
        if (isHit == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        
        float distance = Vector2.Distance(transform.localPosition, player.transform.localPosition);

        if (distance > 5.0f || player.isAlive==false)
        {
            isHit = false;
            anim.SetBool("isCombat", false);
        }

        Vector2 direction = player.transform.localPosition - transform.localPosition;
        if (direction.x > 0 && anim.GetBool("isCombat") == true)
        {

            sprite.flipX = false;
        }
        else if (direction.x < 0 && anim.GetBool("isCombat") == true)
        {
            sprite.flipX = true;
        }
    }

    public virtual void Damage(float damagePoint)
    {
        if (isDead == true)
        {
            return;
        }

        health-=(int)damagePoint;
        anim.SetTrigger("isHit");
        isHit = true;
        anim.SetBool("isCombat", true);

        if (health < 1)
        {
            isDead = true;
            AudioSource.PlayClipAtPoint(_deathsound, Camera.main.transform.position, _deathSoundVolume);
            anim.SetTrigger("isDeath");
            GameObject Coin = Instantiate(coinPrefab, transform.position, Quaternion.identity) as GameObject;
            Coin.GetComponent<Coin>().coinValue = coins;
            Destroy(gameObject, 0.5f);
        }
    }
}
