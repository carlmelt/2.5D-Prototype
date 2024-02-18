using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class Stats : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    Enemy entity;

    void Awake(){
        entity = GetComponent<Enemy>();
    }

    void Start(){
        healthBar.maxValue = entity.MaxHealth;
        healthBar.value = entity.CurrentHealth;
    }
    
    void OnEnable(){
        entity.Damage += UpdateBar;
    }

    void OnDisable(){
        entity.Damage -= UpdateBar;
    }

    void UpdateBar(int value){
        healthBar.value = entity.CurrentHealth;
    }
}
