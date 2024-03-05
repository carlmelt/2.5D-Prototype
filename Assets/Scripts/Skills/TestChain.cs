using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Chained Skill", menuName = "Skills/Chained Skill")]
public class TestChain : BaseSkill, IChainedSkill
{
    [SerializeField] List<BaseSkill> _skillChain = new List<BaseSkill>();
    public List<BaseSkill> skillChain { get => _skillChain; set {_skillChain = value;} }

    public override void Activate(SkillController owner){
        owner.StartCoroutine(ChainSkill(owner));
    }
    public IEnumerator ChainSkill(SkillController owner){
        // Animator ownerAnimator = owner.GetComponent<PlayerController>().playerAnimator;
        for (int i = 0; i < _skillChain.Count; i++){
            _skillChain[i].isCooldown = false;
            owner.Skill(_skillChain[i]);
            yield return new WaitForSeconds(_skillChain[i].castTime + 0.01f);
        }
    }
    
}
