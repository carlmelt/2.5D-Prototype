using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] _CharacterController characterController;
    [SerializeField] PlayerCombo comboController;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private bool canAttack = true;
    private bool canWalk = true;
    public float walkSpeed = 40f;
    float cooldownTime = 0;

    // Update is called once per frame
    void Update()
    {
        if(canWalk){
            horizontalMove = Input.GetAxisRaw("Horizontal");// * walkSpeed;
            verticalMove = Input.GetAxisRaw("Vertical");// * walkSpeed;
        }
        if (Input.GetMouseButtonDown(0) && canAttack){
            cooldownTime = 0;
            canAttack = false;
            //reset walk dir, render walk impossible
            horizontalMove = 0;
            verticalMove = 0;
            canWalk = false;
            //attack
            comboController.Attack();
        }
        comboController.playerAnimator.SetBool("isWalking", (Mathf.Abs(horizontalMove) > 0 || (Mathf.Abs(verticalMove)) > 0));//refactor
    }

    void FixedUpdate(){
        characterController.Move(new Vector2(horizontalMove,verticalMove).normalized * walkSpeed * Time.fixedDeltaTime);
        cooldownTime += Time.fixedDeltaTime;
        if (cooldownTime > 0.3f){
            canAttack = true;
            canWalk = true;
            for (int i=0; i < 3; i++){
                comboController.playerAnimator.ResetTrigger("Attack"+i.ToString());
            }
        }
        if (cooldownTime > 0.6f){//reset
            comboController.currentCombo = 0;
        }
    }

    void Slide(float distance){//refactor
        characterController.Move(new Vector2(distance*transform.localScale.x, 0f));
    }

}
