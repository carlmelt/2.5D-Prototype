using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dash Skill", menuName = "Skills/Dash")]
public class DashSkill : BaseSkill, ICustomAnimation
{
    [SerializeField] AnimationClip dashAnimation;
    public AnimationClip customAnimation {get => dashAnimation;}
    public float dashForce;
    public float InvicibleTime = 0.25f;
    public override void Activate(PlayerController owner)
    {
        MovementController player = owner.GetComponent<MovementController>();
        player.Dash(dashForce);
        player.StartCoroutine(owner.Invincible(InvicibleTime));
    }


}
