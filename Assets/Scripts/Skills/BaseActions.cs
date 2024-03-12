using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseActions : ScriptableObject
{
    public string actionName;
    [TextArea] public string description;
    public float castTime;
    public bool isUnlocked;
    public virtual void Activate(PlayerController owner) { }
}

public interface ISkill {
    float cooldown {get; set;}
    bool isCooldown {get; set;}
    bool isUltimate {get; set;}
    // virtual void Activate(SkillController owner){}
}

public interface IAttack {
    // AnimationClip attackTransition {get; set;}
    int damage {get;}
}

public interface ICustomAnimation {
    AnimationClip customAnimation {get;}
}

