using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    public Animator playerAnimator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public float attackDamage = 5f;

    [SerializeField] private int comboCount = 3;
    public int currentCombo = 0;
    
    public void Attack(){//refactor
        playerAnimator.SetTrigger("Attack"+currentCombo.ToString());
        currentCombo += 1;
        if (currentCombo >= comboCount) currentCombo = 0;
        //Get overlapping entities
        Collider[] hitEntities = Physics.OverlapSphere(attackPoint.position, attackRange);
        foreach(Collider Entities in hitEntities){
            Enemy entityStats = Entities.GetComponent<Enemy>();
            //Check if entity have stats. if not, continue the loop
            entityStats?.Damaged(Mathf.FloorToInt(attackDamage));
        }
    }

    void OnDrawGizmosSelected(){ //draw sphere in editor to see the range.
        if (attackPoint == null) return;
        Gizmos.DrawSphere(attackPoint.position, attackRange);
    }
}
