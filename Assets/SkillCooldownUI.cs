using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCooldownUI : MonoBehaviour
{
    public SkillController playerSkill;
    public List<BaseSkill> skills;
    public List<Button> skillButtons = new List<Button>{};

    void Start(){
        playerSkill = FindObjectOfType<SkillController>();
        playerSkill.StartCooldown += (cd, skill) => StartCoroutine(OverlayCooldown(cd, skill));
        foreach (Transform child in transform){
            skillButtons.Add(child.GetComponent<Button>());
        }
        Player player = playerSkill.GetComponent<Player>();
        skills = new List<BaseSkill> {player.playerContainer.skill1, player.playerContainer.skill2, player.playerContainer.ultimateSkill, player.playerContainer.dashSkill};
    }

    void OnDisable(){
        playerSkill.StartCooldown -= (cd, skill) => StartCoroutine(OverlayCooldown(cd, skill));
    }

    IEnumerator OverlayCooldown(float cooldown, BaseSkill skillUsed){
        float durationLeft = cooldown;
        Image CDOverlay = skillButtons[skills.IndexOf(skillUsed)].transform.GetChild(1).gameObject.GetComponent<Image>();
        while (durationLeft > 0){
            durationLeft -= Time.fixedDeltaTime;
            durationLeft = Mathf.Max(0, durationLeft);
            // Debug.Log(durationLeft);
            CDOverlay.fillAmount = durationLeft / cooldown;
            yield return new WaitForFixedUpdate();
        }
    }
}
