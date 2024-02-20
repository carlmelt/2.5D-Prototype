using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public event Action<float> SkillCasted = delegate {};
    public Animator playerAnimator;
    public BaseSkill skill;
    public bool canSkill = true;
    public float skillCooldown;
    public GameObject skillEffect;
    public Transform skillSpawnPoint;
    AnimatorOverrideController animatorOverrider;
    AnimationClip currentAnimation;

    private void Awake() {
        playerAnimator = GetComponent<Animator>();
        animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        playerAnimator.runtimeAnimatorController = animatorOverrider;
        skillCooldown = skill.cooldown;
        currentAnimation = animatorOverrider["TestFireSlash"];
    }
    public void Skill(){
        if (canSkill){
            animatorOverrider[currentAnimation] = skill.skillAnim;
            // currentAnimation = skill.skillAnim;
            // Debug.Log(animatorOverrider.clips);
            // Debug.Log(currentAnimation);
            skill.Activate(this);
            canSkill = false;
            playerAnimator.SetTrigger("Skill");
            // GameObject particleGO = Instantiate(skillEffect, skillSpawnPoint.position, skillSpawnPoint.rotation);
            // Destroy(particleGO, 2f);
            SkillCasted.Invoke(skill.castTime);
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
