using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dash Skill", menuName = "Skills/Dash")]
public class DashSkill : BaseSkill
{

    public float dashForce;
    public float InvicibleTime = 0.25f;
    public override void Activate(PlayerSkill owner)
    {
       _CharacterController player = owner.GetComponent<_CharacterController>();
       player.Dash(dashForce);
       player.StartCoroutine(player.Invicible(InvicibleTime, player));
    }

    
}
