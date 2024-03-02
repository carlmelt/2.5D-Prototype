using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public event Action<float> SkillCasted = delegate {};
    public event Action<float> StartCooldown = delegate {};
    public Animator playerAnimator;
    public bool canSkill = true;
    [SerializeField] private float currentCooldown;
    public float skillCooldown;
    public Transform skillSpawnPoint;
    AnimatorOverrideController animatorOverrider;
    private void Awake() {
        playerAnimator = GetComponent<Animator>();
        // animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        // playerAnimator.runtimeAnimatorController = animatorOverrider;
        if (playerAnimator != null) {
            animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
            playerAnimator.runtimeAnimatorController = animatorOverrider;
        }
    }
    public void Skill(BaseSkill skillToUse){
        if(skillToUse.isCooldown) return;


        if (!playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("SkillCast")){
            skillCooldown = skillToUse.cooldown;
            currentCooldown = skillCooldown;
            animatorOverrider["TestFireSlash"] = skillToUse.skillAnim; //The default skill anim is TestFireSlash
            // currentAnimation = skill.skillAnim;
            // Debug.Log(animatorOverrider.clips);
            // Debug.Log(currentAnimation);
            skillToUse.Activate(this);
            skillToUse.isCooldown = true;
            playerAnimator.SetTrigger("Skill");
            // GameObject particleGO = Instantiate(skillEffect, skillSpawnPoint.position, skillSpawnPoint.rotation);
            // Destroy(particleGO, 2f);
            SkillCasted.Invoke(skillToUse.castTime);
            StartCoroutine(SkillCooldown(skillCooldown, skillToUse));
            // checkSkillCooldown(skillToUse);
        }
    }

    IEnumerator SkillCooldown(float Cd, BaseSkill skill)
    {
        float remainingTime = Cd;
        while (remainingTime > 0)
        {
            Debug.Log("Remaining Time: " + remainingTime);
            remainingTime -= Time.fixedDeltaTime;
            Debug.Log("Skill is on cooldown for " + remainingTime + " seconds");
            yield return new WaitForFixedUpdate();
        }
        // yield return null;
        // StartCooldown.Invoke(Cd);
        skill.isCooldown = false;
        Debug.Log("Skill Ready");
    }

    public void checkSkillCooldown(BaseSkill skill){
        if (!skill.isCooldown) return;
        else {
            float cd = currentCooldown;
            cd -= Time.fixedDeltaTime;
            currentCooldown = cd;
            Debug.Log("Skill is on cooldown for " + cd + " seconds");
            // while(Time.time - cd > skill.cooldown) {
            //     cd -= Time.fixedDeltaTime;
            // }
            // cd -= Time.fixedDeltaTime;
            // Debug.Log("Skill is on cooldown for " + cd + " seconds");
        }
    }
}
