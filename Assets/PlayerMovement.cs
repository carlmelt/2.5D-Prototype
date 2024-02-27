using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] _CharacterController characterController; //why the name is _CharacterController? it should be CharacterController
    //This because the name CharacterController is already used by Unity Engine
    [SerializeField] PlayerCombo comboController;

    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private bool canAttack = true;
    private bool canWalk = true;
    public float walkSpeed = 40f;
    private PlayerInput playerInput;
    float cooldownTime = 0;
    private Vector2 playerMove;
    float dashForce = 500f;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Start(){
        // characterController.playerSkill.SkillCasted += (_castTime)=>StartCoroutine(SkillCast(_castTime));
        characterController.playerSkill.SkillCasted += Freeze;
    }

    void OnDisable(){
        // characterController.playerSkill.SkillCasted -= (_castTime)=>StartCoroutine(SkillCast(_castTime));
        characterController.playerSkill.SkillCasted -= Freeze;
    }

    // Update is called once per frame
    void Update()
    {
        if (canWalk)
        {
            playerMove = playerInput.actions["Move"].ReadValue<Vector2>();
            // horizontalMove = Input.GetAxisRaw("Horizontal");// * walkSpeed;
            // verticalMove = Input.GetAxisRaw("Vertical");// * walkSpeed;
        }
        if (playerInput.actions["Attack"].triggered && canAttack)
        { //Attack Button
            cooldownTime = Time.time;
            canAttack = false;
            //reset walk dir, render walk impossible
            playerMove = Vector2.zero;
            canWalk = false;
            //attack
            comboController.Attack();
        }
        if (playerInput.actions["Dash"].triggered)
        {//Dash Button
            if (characterController.canDash == true)
            {
                comboController.playerAnimator.SetTrigger("Dash");
                characterController.Dash(dashForce);
                characterController.canDash = false;
                StartCoroutine(characterController.DashCooldown(1f));
            }
            comboController.currentCombo = 0;

        }
        comboController.playerAnimator.SetBool("isWalking", (Mathf.Abs(playerMove.x) > 0 || (Mathf.Abs(playerMove.y)) > 0));//refactor

        if (playerInput.actions["Skill"].triggered)
        {//Skill Button
            // characterController.playerSkill.currentSkill = SkillHolder.skill1;
            characterController.playerSkill.Skill();
        }
    }

    void FixedUpdate()
    {
        characterController.Move(new Vector2(playerMove.x, playerMove.y).normalized * walkSpeed * Time.fixedDeltaTime);
        // cooldownTime += Time.fixedDeltaTime;

        if (Time.time - cooldownTime > 0.3f)
        {
            canAttack = true;
            canWalk = true;
            for (int i = 0; i < 3; i++)
            {
                comboController.playerAnimator.ResetTrigger("Attack" + i.ToString());
            }
        }
        if (Time.time - cooldownTime > 0.6f)
        {//reset
            comboController.currentCombo = 0;
        }
    }

    void Slide(float distance)
    {//refactor
        characterController.Move(new Vector2(distance * transform.localScale.x, 0f));
    }

    void Freeze(float timeOffset=0.3f){
        canWalk = false;
        canAttack = false;
        playerMove = Vector2.zero;
        cooldownTime = Time.time + (timeOffset - 0.3f);
    }

    // IEnumerator SkillCast(float skillCastTime)
    // {
    //     canWalk = false;
    //     canAttack = false;
    //     playerMove = Vector2.zero;
    //     cooldownTime = Time.time + (skillCastTime - 0.3f);
    //     yield return new WaitForSeconds(skillCastTime - 0.2f);
    // }
}
