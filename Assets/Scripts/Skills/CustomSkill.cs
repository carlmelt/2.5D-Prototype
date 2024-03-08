using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[CreateAssetMenu(fileName = "New Custom Skill", menuName = "Skill/Custom")]

public class CustomSkill : BaseSkill
{
    public GameObject skillVFX;
    
    public override void Activate(SkillController owner)
    {
        Transform spawnPoint = owner.skillSpawnPoint;
        //wait for 0.5s

        //spawn the skill VFX
        GameObject skillVFXSpawn = Instantiate(skillVFX, new Vector3(spawnPoint.position.x,0.1f,spawnPoint.position.z), spawnPoint.rotation);
        //play the skill VFX
        // VisualEffect _skillVFX = skillVFXSpawn.GetComponent<VisualEffect>();
        // if (_skillVFX != null) _skillVFX.Play();
        Destroy(skillVFXSpawn, 5f);
        //dash the player
        owner.StartCoroutine(DashFront(owner));
    }

    IEnumerator DashFront(SkillController owner){
        yield return new WaitForSeconds(0.3f);
       MovementController player = owner.GetComponent<MovementController>();
       player.Dash(1000);
        // Vector3 Direction = player.facingRight ? Vector3.right : Vector3.left; //change to player's direction based on player's facing direction
        // player.charRigid.AddForce(Direction * 1000); //add force to the player
    }
}
