using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurningGround : MonoBehaviour
{
    [SerializeField] private float _startFireTime;
    [SerializeField] private GameObject _firePrefab;

    Coroutine burningCoroutine;
    GameObject burningFire;
    bool continueFire = true;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        continueFire = true;
        burningCoroutine = StartCoroutine(StartFire());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag== "Player")
        {
            StopCoroutine(burningCoroutine);
            continueFire = false;
            Destroy(burningFire, 0.5f);
        }
       
    }


    IEnumerator StartFire()
    {
        while (continueFire)
        {
            yield return new WaitForSeconds(_startFireTime);
            burningFire = (GameObject)Instantiate(_firePrefab, new Vector2(transform.position.x - 0.25f, transform.position.y + 2.58f), Quaternion.identity);
        }
    }
}
