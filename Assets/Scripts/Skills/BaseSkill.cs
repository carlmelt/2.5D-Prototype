using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Image = UnityEngine.UIElements.Image;

public abstract class BaseSkill : BaseActions, ISkill
{
    public Sprite skillIcon; //skillOnly
    public AnimationClip skillAnim;
    [SerializeField] float _cooldown;
    public float cooldown {get => _cooldown; set { _cooldown = value;}} //skillOnly

    [SerializeField] bool _isUltimate;
    public bool isUltimate {get => _isUltimate; set { _isUltimate = value;}} //skillOnly
    [SerializeField] bool _isCooldown;
    public bool isCooldown {get => _isCooldown; set { _isCooldown = value;}} //New for skill cooldown check //skillOnly
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
