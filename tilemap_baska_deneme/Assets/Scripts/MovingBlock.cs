using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] Vector3 _posA, _posB;
    [SerializeField] float _speed;

    bool isMove = true;

    void Update()
    {
        if (isMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, _posB, _speed * Time.deltaTime);
            if (transform.position == _posB)
            {
                isMove = false;
            }
        }

        if (isMove == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, _posA, _speed * Time.deltaTime);
            if (transform.position == _posA)
            {
                isMove = true;
            }
        }
    }
}
