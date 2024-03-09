using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack", menuName = "Attacks/Basic Attack")]
public class BaseAttack : BaseActions, IAttack, ICustomAnimation
{
    [SerializeField] AnimationClip attackAnimation;
    public AnimationClip customAnimation {get => attackAnimation;}
    public AnimationClip attackTransition;
    [SerializeField] int attackDamage;
    [SerializeField] GameObject attackProjectile;
    public int damage {get => attackDamage;}

    public override void Activate(PlayerController owner)
    {
        AttackController ownerAttack = owner.GetComponent<AttackController>();
        Transform ownerAttackPoint = ownerAttack.attackPoint;
        if (attackProjectile != null) { 
            GameObject _attackProjectile = Instantiate(attackProjectile, ownerAttackPoint.position, ownerAttackPoint.rotation);
        }
    }

}
