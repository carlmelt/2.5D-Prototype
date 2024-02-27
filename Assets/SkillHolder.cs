using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public event Action<float> SkillCasted = delegate {};
    public event Action<float> StartCooldown = delegate {};
    public Animator playerAnimator;
    public BaseSkill currentSkill;
    public static BaseSkill skill1;
    public static BaseSkill skill2;
    public bool canSkill = true;
    public float skillCooldown;
    public GameObject skillEffect;
    public Transform skillSpawnPoint;
    AnimatorOverrideController animatorOverrider;

    private void Awake() {
        playerAnimator = GetComponent<Animator>();
        animatorOverrider = new AnimatorOverrideController(playerAnimator.runtimeAnimatorController);
        playerAnimator.runtimeAnimatorController = animatorOverrider;
        skillCooldown = currentSkill.cooldown;
    }
    public void Skill(){
        if (canSkill && !playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("SkillCast")){
            animatorOverrider["TestFireSlash"] = currentSkill.skillAnim; //The default currentSkill anim is TestFireSlash
            // currentAnimation = currentSkill.skillAnim;
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

    IEnumerator SkillCooldown(float Cd)
    {
        yield return new WaitForSeconds(Cd);
        canSkill = true;
        Debug.Log("Skill Ready");
    }
}
