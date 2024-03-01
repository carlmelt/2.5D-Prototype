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
        if (canSkill && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("SkillCast")){
            skillCooldown = skillToUse.cooldown;
            animatorOverrider["TestFireSlash"] = skillToUse.skillAnim; //The default skill anim is TestFireSlash
            // currentAnimation = skill.skillAnim;
            // Debug.Log(animatorOverrider.clips);
            // Debug.Log(currentAnimation);
            skillToUse.Activate(this);
            canSkill = false;
            playerAnimator.SetTrigger("Skill");
            // GameObject particleGO = Instantiate(skillEffect, skillSpawnPoint.position, skillSpawnPoint.rotation);
            // Destroy(particleGO, 2f);
            SkillCasted.Invoke(skillToUse.castTime);
            StartCoroutine(SkillCooldown(skillCooldown));
        }
    }

    IEnumerator SkillCooldown(float Cd)
    {
        yield return new WaitForSeconds(Cd);
        canSkill = true;
        Debug.Log("Skill Ready");
    }
}
