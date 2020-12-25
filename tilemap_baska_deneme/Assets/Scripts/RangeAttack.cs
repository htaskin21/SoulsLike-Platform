using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 1.75f;
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _rangeAttackDamage;

    private Ghost _ghost;
    private bool isleft = true;


    private void Start()
    {
        _ghost = GameObject.Find("Ghost_Enemy").GetComponent<Ghost>();
        Destroy(this.gameObject, _destroyTime);

        if (_ghost.transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
            isleft = true;
        }
        else if (_ghost.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
            isleft = false;
        }
    }

    void Update()
    {
        if (isleft == true)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else if (isleft == false)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageble hit = other.GetComponent<IDamageble>();
            if (hit != null)
            {
                hit.Damage(_rangeAttackDamage);
                Destroy(gameObject);
            }
        }
    }
}
