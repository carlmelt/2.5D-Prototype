using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public event Action<float> SkillCasted = delegate { };
    public event Action<float, BaseSkill> StartCooldown = delegate { };
    private Animator playerAnimator;
    public bool canSkill = true;

    public float skillCooldown;
    public Transform skillSpawnPoint;
    AnimatorOverrideController animatorOverrider;
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
    }
    public void Skill(BaseSkill skillToUse)
    {
        if (skillToUse.isCooldown) return;
        //---
        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("SkillCast"))
        {
            //Reference the skill cooldown
            skillCooldown = skillToUse.cooldown;
            //Set the skill animation
            animatorOverrider["TestFireSlash"] = skillToUse.skillAnim; //The default skill anim is TestFireSlash
            //Activate the skill
            skillToUse.Activate(this);
            skillToUse.isCooldown = true; //Set the skill on cooldown
            playerAnimator.SetTrigger("Skill");//Play the skill animation
            SkillCasted.Invoke(skillToUse.castTime);//Invoke the skill casted event that can freeze the player
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


}
