using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//For storing chardata (if stats modified by lvl)
public abstract class CharacterContainer : ScriptableObject
{
    public string Name;
    // public PlayerStats character;
    public CharacterStats stats;
    public int Level;
    // public float experiencePoint;
    //public Weapon characterWeapon;
    // public BaseSkill characterSkill1;
    // public BaseSkill characterSkill2;
    // public BaseSkill characterUltimateSkill;
}
