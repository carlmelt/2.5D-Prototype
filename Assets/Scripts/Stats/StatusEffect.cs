using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : ScriptableObject
{
    public string effectName;
    public string description;
    public float duration;

    public enum effectType
    {
        Buff,
        Debuff
    }

    public enum affectedStat
    {
        Health,
        Attack,
        Defense,
        CritChance,
        CritDamage,
        AttackSpeed,
        MovementSpeed
    }

    public List<affectedStat> affectedStatsList = new List<affectedStat>();
    public abstract void ApplyEffect();
    public abstract void RemoveEffect();
}
