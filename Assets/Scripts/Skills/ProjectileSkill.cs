using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New Projectile Skill", menuName = "Skill/Projectile")]

public class ProjectileSkill : BaseSkill
{
    public GameObject projectile;
    public override void Activate(SkillHolder owner){
        Transform spawnPoint = owner.skillSpawnPoint;
        GameObject projectileSpawn = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
        ProjectileAnimator _projectile = projectileSpawn.GetComponent<ProjectileAnimator>();
        if (_projectile != null) _projectile.owner = owner;
        Destroy(projectileSpawn, 2f);
    }
}
