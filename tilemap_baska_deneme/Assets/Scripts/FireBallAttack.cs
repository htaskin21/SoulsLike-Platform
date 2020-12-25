using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallAttack : MonoBehaviour
{
    [SerializeField] private float _destroyTime = 1.75f;
    [SerializeField] private float _speed = 3f;

    [SerializeField] private float _fireBallDamage;

    private Wizard _wizard;
    private bool _isleft = true;


    private void Start()
    {
        _wizard = GameObject.Find("Wizard_Enemy").GetComponent<Wizard>();
        Destroy(this.gameObject, _destroyTime);

        if (_wizard.transform.localScale.x > 0)
        {
            transform.localScale = new Vector2(-1, 1);
            _isleft = true;
        }
        else if (_wizard.transform.localScale.x < 0)
        {
            transform.localScale = new Vector2(1, 1);
            _isleft = false;
        }
    }

    void Update()
    {
        if (_isleft == true)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
        }
        else if (_isleft == false)
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
                hit.Damage(_fireBallDamage);
                Destroy(gameObject);
            }
        }
    }
}
