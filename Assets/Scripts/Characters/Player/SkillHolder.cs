using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public event Action<float> SkillCasted = delegate {};
    public event Action<float> StartCooldown = delegate {};
    public event Action<int, BaseSkill> skillChanged = delegate {};
    public Animator playerAnimator;
    public BaseSkill currentSkill;
    public static BaseSkill skill1;
    public static BaseSkill skill2;
    public static BaseSkill ultimateSkill;
    public bool canSkill = true;
    public float skillCooldown;
    public Transform skillSpawnPoint;
    AnimatorOverrideController animatorOverrider;
    
    // public static BaseSkill skill2;
    // public static SOUltimat ultimate;

    private void Awake() {
        playerAnimator = GetComponent<Animator>();
        // animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        // playerAnimator.runtimeAnimatorController = animatorOverrider;
        if (playerAnimator != null) {
            animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
            playerAnimator.runtimeAnimatorController = animatorOverrider;
        }
        skillCooldown = currentSkill.cooldown;
        //testing purpose:
        skill1 = currentSkill;
    }
    public void Skill(){
        if (canSkill && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("SkillCast")){
            animatorOverrider["TestFireSlash"] = currentSkill.skillAnim; //The default skill anim is TestFireSlash
            // currentAnimation = skill.skillAnim;
            // Debug.Log(animatorOverrider.clips);
            // Debug.Log(currentAnimation);
            currentSkill.Activate(this);
            canSkill = false;
            playerAnimator.SetTrigger("Skill");
            // GameObject particleGO = Instantiate(skillEffect, skillSpawnPoint.position, skillSpawnPoint.rotation);
            // Destroy(particleGO, 2f);
            SkillCasted.Invoke(currentSkill.castTime);
            StartCoroutine(SkillCooldown(skillCooldown));
        }
    }

    public void ChangeSkill(BaseSkill oldSkill, BaseSkill newSkill){
        int skillTargetIndex;
        if (skill1 == oldSkill) {
            skill1 = newSkill;
            skillTargetIndex = 0;
        }
        else if(skill2 == oldSkill){
            skill2 = newSkill;
            skillTargetIndex = 1;
        }
        else if (ultimateSkill == oldSkill){
            ultimateSkill = newSkill;
            skillTargetIndex = 2;
        }
        else{
            Debug.Log("Unknown Error. No target skill/ultimate found.");
            return;
        }
        skillChanged?.Invoke(skillTargetIndex, newSkill);
    }

    IEnumerator SkillCooldown(float Cd)
    {
        yield return new WaitForSeconds(Cd);
        canSkill = true;
        Debug.Log("Skill Ready");
    }
}
