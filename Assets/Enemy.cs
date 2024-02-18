using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject deadParticle;
    public event Action<int> Damage = delegate {};
    public event Action<int> Healed = delegate {};
    public event Action Dead = delegate {};
    [SerializeField] int _maxHealth;
    public int MaxHealth => _maxHealth;
    int _currentHealth;
    public int CurrentHealth{
        get => _currentHealth;
        set {
            if (value > _maxHealth) value = _maxHealth;
            _currentHealth = value;
        }
    }
    
    void Awake(){
        CurrentHealth = _maxHealth;
    }

    public void Damaged(int amount){
        _currentHealth -= amount;
        Damage?.Invoke(amount);
        if (_currentHealth <= 0){
            Die();
        }
        Debug.Log("Damaged! :" + amount +", Current Health:" + _currentHealth);
    }

    void Die(){
        Dead.Invoke();
        GameObject deadFx = Instantiate(deadParticle, transform.position, new Quaternion(-90,0,0,90));
        Destroy(deadFx, 3);
        Destroy(gameObject);
    }
}
