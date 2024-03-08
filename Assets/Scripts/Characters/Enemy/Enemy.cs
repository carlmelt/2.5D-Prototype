using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deadParticle;
    public event Action Damage = delegate { };
    public event Action<int> Healed = delegate { };
    public event Action Dead = delegate { };
    [SerializeField] int _maxHealth;
    [SerializeField] GameObject hitEffect;
    public int MaxHealth => _maxHealth;
    int _currentHealth;
    public int CurrentHealth
    {
        get => _currentHealth;
        set
        {
            if (value > _maxHealth) value = _maxHealth;
            _currentHealth = value;
        }
    }

    bool isInvincible;
    bool _isInvincible { 
        get => isInvincible;
        set
        {
            isInvincible = value;
            // Physics.IgnoreLayerCollision(LayerMask.NameToLayer("PlayerVFX"), LayerMask.NameToLayer("Enemy"), value);
        }
    }

    void Awake()
    {
        CurrentHealth = _maxHealth;
    }

    public void Damaged(int amount)
    {
        if(isInvincible) return;
        _currentHealth -= amount;
        Damage?.Invoke();
        GameObject enemyHitEffect = Instantiate(hitEffect, transform.position, new Quaternion(0,0,0,0));
        Destroy(enemyHitEffect, 3f);
        StartCoroutine(Invincible(0.15f));
        if (_currentHealth <= 0)
        {
            Die();
        }
        Debug.Log("Damaged! :" + amount + ", Current Health:" + _currentHealth);
    }

    void Die()
    {
        Dead.Invoke();
        GameObject deadFx = Instantiate(deadParticle, transform.position, new Quaternion(-90, 0, 0, 90));
        Destroy(deadFx, 3);
        Destroy(gameObject);
    }

    IEnumerator Invincible(float duration){
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }
}
