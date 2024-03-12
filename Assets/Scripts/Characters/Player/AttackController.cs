using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    /*============================================NOTES============================================
    This script is responsible for handling the player's attack. It is also responsible for detecting the enemy and dealing damage to them.
    This script is temporary use for testing dummy combo, and will be replaced by the character's specific attack script later.
    */

    [Header("Attack Components")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage = 5f;

    [Header("Combo")]
    [SerializeField] private int comboCount = 3;
    public int currentCombo = 0;
    AnimatorOverrideController animatorOverride;
    PlayerContainer player;

    void Awake(){
        player = GetComponent<Player>().playerContainer;
        comboCount = player.playerAttacks.Count;
    }

    void Start(){
        animatorOverride = GetComponent<SkillController>().animatorOverrider;
    }

    // Replace the Combo system here with the new combo system based on playerContainer`s Properties
    public void Attack(Animator playerAnimator)
    {//refactor
        // playerAnimator.SetTrigger("Attack" + currentCombo.ToString());
        animatorOverride["Attack1"] = player.playerAttacks[currentCombo].customAnimation;
        playerAnimator.SetTrigger("Attack0");
        player.playerAttacks[currentCombo].Activate(GetComponent<PlayerController>());
        currentCombo += 1;
        if (currentCombo >= comboCount) currentCombo = 0;
        //Get overlapping entities
        Collider[] hitEntities = Physics.OverlapSphere(attackPoint.position, attackRange);
        foreach (Collider Entities in hitEntities)
        {
            Enemy entityStats = Entities.GetComponent<Enemy>();
            //Check if entity have stats. if not, continue the loop
            entityStats?.Damaged(Mathf.FloorToInt(attackDamage));
        }
    }

    void OnDrawGizmosSelected()
    { //draw sphere in editor to see the range.
        if (attackPoint == null) return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
