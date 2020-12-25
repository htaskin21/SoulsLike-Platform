using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _playerRigidBody;
    private PlayerAnimation _playerAnimation;
    private Player _player;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _jumpForce = 5f;

    private bool _resetJumpNeeded = false;
    public bool isAlive = true;


    void Start()
    {
        _playerRigidBody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
        _player = GetComponent<Player>();
    }

    void Update()
    {
        if (isAlive)
        {           
            Jump();            
            CheckGrounded();
            Attack();
            Debug.DrawRay(transform.position, Vector2.down * 2.0f, Color.green);
        }

        if (transform.position.y<-8.1f)
        {
            FallingDeath();
        }
    }

    private void FixedUpdate()
    {
        if (isAlive)
        {
            Run();
            FlipSprite();
        }
    }

    private void Run()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        //float horizontal = Input.GetAxis("Horizontal");
        Vector2 playerVelocity = new Vector2(horizontal * _speed, _playerRigidBody.velocity.y);
        _playerRigidBody.velocity = playerVelocity;
        if (Mathf.Abs(_playerRigidBody.velocity.x) > Mathf.Epsilon)
        {
            _playerAnimation.Run(true);
        }
        else
        {
            _playerAnimation.Run(false);
        }
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_playerRigidBody.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_playerRigidBody.velocity.x), 1);
        }
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && CheckGrounded() || CrossPlatformInputManager.GetButtonDown("B_Button")  && CheckGrounded())
        {
            _playerRigidBody.velocity = new Vector2(_playerRigidBody.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpNeededRoutine());
            _playerAnimation.Jump(true);
        }
    }

    private bool CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 2.2f, 1 << 8);
        RaycastHit2D hitInfo2 = Physics2D.Raycast(transform.position, Vector2.down, 2.2f, 1 << 14);
        Debug.DrawRay(transform.position, Vector2.down * 1f, Color.green);
        if (hitInfo.collider != null || hitInfo2.collider !=null)
        {
            if (_resetJumpNeeded == false)
            {
                _playerAnimation.Jump(false);
                return true;
            }
        }
        return false;
    }

    IEnumerator ResetJumpNeededRoutine()
    {
        _resetJumpNeeded = true;
        yield return new WaitForSeconds(0.1f);
        _resetJumpNeeded = false;
    }

    private void Attack()
    {
        if (CrossPlatformInputManager.GetButtonDown("A_Button") && CheckGrounded())
        {
            _playerAnimation.Attack();
        }
    }

    public void PlayerDeath()
    {
        isAlive = false;
    }

    public void FallingDeath()
    {
        if (isAlive)
        {
            _player.PlayerDeathProcess();
        }
    }
}
