using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : ScriptableObject
{
    // public string Name;
    public int Health;
    public int Attack;
    public int Defense;
    public float criticalChance;
    public float criticalDamage;
    public int Speed;
    public int Level;
    public Sprite Model;

    //Player
    // public int Energy;
    // public int energyRecovery;

}
