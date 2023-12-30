using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerStatType { Speed, Damage, AttackSpeed, AttackCooldown }
public class Player : MonoBehaviour, IDamagable
{
    [Header("Managers")]
    [SerializeField] private MovementController movementController;
    [SerializeField] private ShootingManager shootingManager;
    [SerializeField] private HealthManager hearts;
    [SerializeField] private GameObject deathPanel;
    
    [Space]
    [SerializeField] private int _health;

    private bool IsDamageTook = false;
    public int Health
    {
        get { return _health; }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                Die();
            }
        }
    }

    public List<Upgrade> activeUpgrades = new List<Upgrade>();
    public List<Weapon> activeWeapons = new List<Weapon>();
    
    private void Awake()
    {
        StartCoroutine(invincibleSecs());
        Time.timeScale = 1f;
        tag = "Player";
    }
    private void Start()
    {
        movementController = GetComponent<MovementController>();
        shootingManager = GetComponent<ShootingManager>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("EnemyBullets"))
        {
            TakeDamage(1);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
        }
    }

    public virtual void Die()
    {
        Time.timeScale = 0f;
        deathPanel.SetActive(true);
    }

    public virtual void TakeDamage(int damageValue)
    {
        if (IsDamageTook == false)
        {
            Health -= damageValue;
            hearts.GetDamage();
            StartCoroutine(invincibleSecs());
        }
    }

    private IEnumerator invincibleSecs()
    {
        IsDamageTook = true;
        yield return new WaitForSeconds(1.5f);
        IsDamageTook = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
