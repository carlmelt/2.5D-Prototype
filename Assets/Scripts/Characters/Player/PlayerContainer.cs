using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Container", menuName = "Character Container/Player Container")]

public class PlayerContainer : CharacterContainer
{
    public float experiencePoint;
    public event Action<int, BaseSkill> skillChanged = delegate { };

    [Header("Player Attacks")]
    public List<BaseAttack> playerAttacks = new List<BaseAttack>();

    [Header("Player Skills")]
    public BaseSkill skill1;
    public BaseSkill skill2;
    public BaseSkill ultimateSkill;
    public BaseSkill dashSkill;

    //Change the skill to the new skill
    public void ChangeSkill(BaseSkill oldSkill, BaseSkill newSkill)
    {
        int skillTargetIndex;

        if (skill1 == newSkill || skill2 == newSkill) return;

        if (skill1 == oldSkill)
        {
            skill1 = newSkill;
            skillTargetIndex = 0;
        }
        else if (skill2 == oldSkill)
        {
            skill2 = newSkill;
            skillTargetIndex = 1;
        }
        else if (ultimateSkill == oldSkill)
        {
            ultimateSkill = newSkill;
            skillTargetIndex = 2;
        }
        else
        {
            Debug.Log("Unknown Error. No target skill/ultimate found.");
            return;
        }
        skillChanged?.Invoke(skillTargetIndex, newSkill); //Subscribe to the event in SkillSelector Script
    }
}
