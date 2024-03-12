using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New Projectile Skill", menuName = "Skill/Projectile")]

public class ProjectileSkill : BaseSkill, IAttack, ICustomAnimation
{
    public GameObject projectile;
    [SerializeField] int _damage;
    public int damage {get => _damage;}
    [SerializeField] AnimationClip attackAnimation;
    public AnimationClip customAnimation {get => attackAnimation; set => attackAnimation = value;}
    public override void Activate(PlayerController owner)
    {
        SkillController playerSkill = owner.playerSkill;
        Transform spawnPoint = playerSkill.skillSpawnPoint;
        GameObject projectileSpawn = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        ProjectileAnimator _projectile = projectileSpawn.GetComponent<ProjectileAnimator>();
        if (_projectile != null) _projectile.owner = playerSkill;
        Destroy(projectileSpawn, 2f);
    }
}
