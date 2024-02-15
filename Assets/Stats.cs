using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stats : MonoBehaviour
{
    [SerializeField] private GameObject Owner;

    [SerializeField] private float maxHealth = 10f;
    public float currentHealth;
    // public UnityEvent<int> OnHit;

    void Awake(){
        Owner = this.gameObject;
    }

    void Start(){
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;

        if (currentHealth <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(Owner);
    }

}
