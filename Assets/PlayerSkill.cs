using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public Animator playerAnimator;
    // public ScriptableObject skill;
    public bool canSkill = true;
    public float skillCooldown;
    public GameObject skillEffect;
    public Transform skillSpawnPoint;

    private void Awake() {
        playerAnimator = GetComponent<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Skill(){
        if (canSkill){
            canSkill = false;
            // playerAnimator.SetTrigger("Skill");
            GameObject particleGO = Instantiate(skillEffect, skillSpawnPoint.position, skillSpawnPoint.rotation);
            Destroy(particleGO, 2f);
            
            StartCoroutine(SkillCooldown(skillCooldown));
        }
    }

    IEnumerator SkillCooldown(float Cd)
    {
        yield return new WaitForSeconds(Cd);
        canSkill = true;
        Debug.Log("Skill Ready");
    }
}
