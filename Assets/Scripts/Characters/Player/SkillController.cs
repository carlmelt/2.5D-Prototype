using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public event Action<float> SkillCasted = delegate { };
    public event Action<float, BaseSkill> StartCooldown = delegate { };
    private Animator playerAnimator;
    public bool canSkill = true;

    IChainedSkill isChainedSkill;
    List<BaseSkill> skillToChain;

    public float skillCooldown;
    public Transform skillSpawnPoint;
    public AnimatorOverrideController animatorOverrider;
    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
        // animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        // playerAnimator.runtimeAnimatorController = animatorOverrider;
        if (playerAnimator != null)
        {
            animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
            playerAnimator.runtimeAnimatorController = animatorOverrider;
        }
        ReloadSkill(); //Refresh skills castTime, to avoid any mismatch in their time
    }
    public void Skill(PlayerController owner, BaseSkill skillToUse)
    {
        if (skillToUse.isCooldown) return;
        Debug.Log("Skill Called");
        //---
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("SkillCast"))
        {
            //Reference the skill cooldown
            //Set the skill animation
            // IAttack attackSkill = skillToUse as IAttack;
            ICustomAnimation skillAnimation = skillToUse as ICustomAnimation;
            // if (attackSkill != null) animatorOverrider["DefaultCast"] = attackSkill.attackAnimation; //The default skill anim is DefaultCast
            if (skillAnimation != null) animatorOverrider["DefaultCast"] = skillAnimation.customAnimation; //The default skill anim is DefaultCast
            if (isChainedSkill == null) isChainedSkill = skillToUse as IChainedSkill; //if skillToUse not a member of chainedSkill, null.
            //Activate the skill
            playerAnimator.SetTrigger("Skill");
            skillToUse.Activate(owner);
            if (skillToUse.castTime > 0) SkillCasted.Invoke(skillToUse.castTime - 0.1f);//Invoke the skill casted event that can freeze the player
            if (isChainedSkill != null){
                skillToChain = isChainedSkill.skillChain;
                if (!skillToChain.Contains(skillToUse)) skillCooldown = skillToUse.cooldown;
                if (skillToUse != skillToChain[skillToChain.Count - 1]){
                    return;
                }//spaghetti code. FIX IT LATER!
                skillToUse = isChainedSkill as BaseSkill;
                isChainedSkill = null;
                skillToChain = null;
            }
            else {
                skillCooldown = skillToUse.cooldown;
            }
            Debug.Log("HIHI");
            skillToUse.isCooldown = true; //Set the skill on cooldown
            // playerAnimator.SetTrigger("Skill");//Play the skill animation
            StartCooldown.Invoke(skillCooldown, skillToUse); //Invoke the skill cooldown event for UI cooldown
            StartCoroutine(SkillCooldown(skillCooldown, skillToUse)); //Start the skill cooldown
        }
    }
    IEnumerator SkillCooldown(float Cd, BaseSkill skill)
    {
        float remainingTime = Cd + 0.1f;
        while (remainingTime > 0.1f)
        {
            remainingTime -= Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }
        skill.isCooldown = false;
        Debug.Log("Skill Ready");
    }

    void ReloadSkill() {
        PlayerContainer player = GetComponent<Player>().playerContainer;
        List<BaseSkill> skills = new List<BaseSkill> {player.skill1, player.skill2, player.ultimateSkill, player.dashSkill};
        foreach(BaseSkill skill in skills){
            // IAttack attackSkill = skill as IAttack;
            ICustomAnimation skillAnimation = skill as ICustomAnimation;
            skill.castTime = (skillAnimation != null) ? (skillAnimation.customAnimation != null) ? skillAnimation.customAnimation.length : 0 : animatorOverrider["DefaultCast"].length;
            // if(attackSkill != null) skill.castTime = attackSkill.attackAnimation.length;
        }
    }

}
