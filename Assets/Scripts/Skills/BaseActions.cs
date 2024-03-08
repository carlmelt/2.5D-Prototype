using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActions : ScriptableObject
{
    public string actionName;
    public string description;
    public int damage;
    public float castTime;
    public bool isUnlocked;
    // public virtual void Activate() { }
}

public interface ISkill {
    public float cooldown {get; set;}
    public bool isCooldown {get; set;}
    public bool isUltimate {get; set;}
    public virtual void Activate(SkillController owner){}
}

public interface IAttack {
    public AnimationClip attackAnimation {get; set;}
    public virtual void ActivateAttack(AttackController owner){}
}

public interface IPositionModifier {
    public float moveDelay {get; set;}
    public void ActivateMove(MovementController owner){}
}