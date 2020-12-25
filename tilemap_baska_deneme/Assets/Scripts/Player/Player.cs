using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageble
{
    private PlayerAnimation _playerAnimation;
    private PlayerMovement _playerMovement;
    private SpriteRenderer _spriteRenderer;
    private PlayerSounds _playerSounds;


    [SerializeField] public int coinCount;

    private bool _canTakeDamage = true;
    private bool _isPoisened = false;
    public float Health { get; set; }

    private void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerMovement = GetComponent<PlayerMovement>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _playerSounds = GetComponent<PlayerSounds>();
        MainGameUI.Instance.UpdateCoinText(coinCount);
    }

    public void AddCoins(int coins)
    {
        coinCount += coins;
        MainGameUI.Instance.UpdateCoinText(coinCount);
    }

    public void Damage(float damagePoint)
    {
        if (PlayerStats.Instance.Health <= damagePoint)
        {
            PlayerStats.Instance.TakeDamage(damagePoint);
            PlayerDeathProcess();
            return;
        }

        if (_canTakeDamage)
        {
            _playerSounds.PlayHitSound();
            PlayerStats.Instance.TakeDamage(damagePoint);
            Debug.Log(PlayerStats.Instance.Health.ToString());
            _playerAnimation.Hit();
            StartCoroutine(DamageDelay());
        }
    }

    public void PlayerDeathProcess()
    {       
        _playerSounds.PlayDeathSound();
        _playerMovement.PlayerDeath();
        _playerAnimation.Death();
        Destroy(this.gameObject, 0.5f);
        MainGameUI.Instance.ActivateDeathScene();
        return;
    }

    public void GetPoisened(int poisonHitTime)
    {
        StartCoroutine(TakePoisonDamage(poisonHitTime));
    }

    IEnumerator DamageDelay()
    {
        if (_isPoisened == false)
        {
            _canTakeDamage = false;
            _spriteRenderer.color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(1f);
            _spriteRenderer.color = new Color(1, 1, 1, 1);
            _canTakeDamage = true;
        }
        else
        {
            _canTakeDamage = false;
            _spriteRenderer.color = new Color(0f, 1f, 0f, 0.5f);
            yield return new WaitForSeconds(1f);
            _spriteRenderer.color = new Color(0f, 1f, 0f, 1f);
            _canTakeDamage = true;
        }
    }

    IEnumerator TakePoisonDamage(int poisonHitTime)
    {
        _isPoisened = true;
        for (int i = 0; i < poisonHitTime; i++)
        {
            Damage(1f);
            yield return new WaitForSeconds(2f);
        }
        _isPoisened = false;
    }

   




}
