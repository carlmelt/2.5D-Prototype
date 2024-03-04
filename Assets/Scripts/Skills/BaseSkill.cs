using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;

public abstract class BaseSkill : ScriptableObject
{
    public string skillName;
    public int damage;
    public Sprite skillIcon;
    public AnimationClip skillAnim;
    public float castTime;
    public float cooldown;
    public bool isUnlocked;
    public bool isUltimate;
    public bool isCooldown; //New for skill cooldown check
    // Start is called before the first frame update
    public virtual void Activate(SkillController owner) { }

    void Awake()
    {
        if (skillAnim) castTime = skillAnim.length;
    }
}

public interface IChainedSkill
{
    public List<BaseSkill> skillChain {get; set;}
    public IEnumerator ChainSkill(SkillController owner);
}
