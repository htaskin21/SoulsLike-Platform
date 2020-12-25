using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingGround : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    [SerializeField] private float _fallingSpeed;

    private bool _isStepOn = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _isStepOn = true;
        }
    }

    private void Update()
    {
        if (_isStepOn == true)
        {
            transform.Translate(Vector3.down * _fallingSpeed * Time.deltaTime);
        }
    }


}
