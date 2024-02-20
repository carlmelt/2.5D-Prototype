using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : ScriptableObject
{
    public string name;
    public int damage;
    public AnimationClip skillAnim;
    public float castTime;
    public float cooldown;
    // Start is called before the first frame update
    public virtual void Activate(SkillHolder owner){}

    void Awake(){
        if (skillAnim) castTime = skillAnim.length;
    }
}
