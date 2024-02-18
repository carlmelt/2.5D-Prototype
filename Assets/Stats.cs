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
        entity.Damage += debugging;
    }

    void OnDisable(){
        entity.Damage -= UpdateBar;
        entity.Damage -= debugging;
    }

    void debugging(){
        Debug.Log("Ngakak Cik!");
    }
    void UpdateBar(){
        Debug.Log("Updating Health Bar");
        healthBar.value = entity.CurrentHealth;
    }
}
