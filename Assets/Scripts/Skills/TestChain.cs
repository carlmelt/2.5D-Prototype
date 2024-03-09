using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chained Skill", menuName = "Skills/Chained Skill")]
public class TestChain : BaseSkill, IChainedSkill, ICustomAnimation
{
    [SerializeField] List<BaseSkill> _skillChain = new List<BaseSkill>();
    public List<BaseSkill> skillChain { get => _skillChain; set {_skillChain = value;} }
    public AnimationClip customAnimation {get;}

    public override void Activate(PlayerController owner){
        owner.StartCoroutine(ChainSkill(owner));
    }
    public IEnumerator ChainSkill(PlayerController owner){
        // Animator ownerAnimator = owner.GetComponent<PlayerController>().playerAnimator;
        yield return new WaitForSeconds(castTime);
        for (int i = 0; i < _skillChain.Count; i++){
            _skillChain[i].isCooldown = false;
            owner.GetComponent<SkillController>().Skill(owner, _skillChain[i]);
            yield return new WaitForSeconds(_skillChain[i].castTime - 0.09f);
        }
    }
    
}
