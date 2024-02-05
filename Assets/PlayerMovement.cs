using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] _CharacterController characterController;
    [SerializeField] Animator playerAnimator;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
    private bool canAttack = true;
    private int comboCount = 0;
    public float walkSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * walkSpeed;
        playerAnimator.SetBool("isWalking", (Mathf.Abs(horizontalMove) > 0 || (Mathf.Abs(verticalMove)) > 0));

        if (Input.GetMouseButtonDown(0) && canAttack){
            StartCoroutine(Attack(comboCount));
        }
    }

    void FixedUpdate(){
        characterController.Move(new Vector2(horizontalMove,verticalMove) * Time.fixedDeltaTime);
    }

    void Slide(float distance){
        characterController.Move(new Vector2(distance*transform.localScale.x, 0f));
    }

    IEnumerator Attack(int combo){
        canAttack = false;
        playerAnimator.SetTrigger("Attack"+combo.ToString());
        yield return new WaitForSeconds(.35f);
        canAttack = true;
        comboCount += 1;
        if (combo >= 2) comboCount = 0;
        yield return new WaitForSeconds(.35f);
        comboCount = 0;
    }
}
