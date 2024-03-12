using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] float colliderDelay;
    Collider projectileCollider;
    CharacterStats playerStats;

    void Start(){
        playerStats = FindObjectOfType<Player>().playerContainer.stats;
        projectileCollider = GetComponent<Collider>();
        projectileCollider.enabled = false;
        StartCoroutine(DelayCollider(colliderDelay));
    }
    
    IEnumerator DelayCollider(float duration){
        yield return new WaitForSeconds(duration);
        projectileCollider.enabled = true;
    }

    void OnTriggerStay(Collider entity){
        if (entity.CompareTag("Enemy")){
            Enemy enemy = entity.GetComponent<Enemy>();
            // enemy.Damage += DebugDuluGaSih;
            //Delay
            enemy?.Damaged(playerStats.Attack);
        }
    }

    // void OnTriggerExit(Collider entity){
    //     if (entity.CompareTag("Enemy")){
    //         Enemy enemy = entity.GetComponent<Enemy>();
    //         enemy.Damage -= DebugDuluGaSih;
    //     }
    // }

    // void DebugDuluGaSih(){
    //     Debug.Log("aw");
    // }
}
