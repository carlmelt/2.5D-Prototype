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
    public bool isCooldown; //New for skill cooldown check
    // Start is called before the first frame update
    public virtual void Activate(SkillController owner){}

    void Awake(){
        if (skillAnim) castTime = skillAnim.length;
    }
}

public interface IChainedSkill {
    public IEnumerator ChainSkill();
}
