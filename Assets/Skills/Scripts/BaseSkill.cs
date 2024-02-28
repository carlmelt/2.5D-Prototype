using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : ScriptableObject
{
    public string skillName;
    public int damage;
    public AnimationClip skillAnim;
    public float castTime;
    public float cooldown;
    public bool isUnlocked;
    public bool isUltimate;
    // Start is called before the first frame update
    public virtual void Activate(SkillHolder owner){}

    void Awake(){
        if (skillAnim) castTime = skillAnim.length;
    }
}
