using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] _CharacterController characterController;
    [SerializeField] Animator playerAnimator;
    private float horizontalMove = 0f;
    private float verticalMove = 0f;
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
    }

    void FixedUpdate(){
        characterController.Move(new Vector2(horizontalMove,verticalMove) * Time.fixedDeltaTime);
    }
}
