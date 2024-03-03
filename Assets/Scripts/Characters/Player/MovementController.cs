using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MovementController : MonoBehaviour
{
    // --------------------------------------------REFACTOR----------------------------------------------------------
    [Header("Movement Related Var")]
    private Rigidbody charRigid;
    private bool facingRight = true;
    private Transform attackPoint;
    private Vector3 m_Velocity = Vector3.zero;
    public float walkSpeed = 40f;
    [Range(0, .3f)][SerializeField] private float m_movementSmoother = .05f;

    void Awake(){
        charRigid = GetComponent<Rigidbody>();
        attackPoint = GetComponent<AttackController>().attackPoint;
    }

    //---------------------------------------------------------------------------------------------------------------------------
    public void Move(Vector2 move)
    {
        //move the character
        Vector3 targetVelocity = new Vector3(move.x, charRigid.velocity.y, move.y);
        charRigid.velocity = Vector3.SmoothDamp(charRigid.velocity, targetVelocity, ref m_Velocity, m_movementSmoother);

        //flip the character
        if (move.x > 0 && !facingRight) Flip();
        else if (move.x < 0 && facingRight) Flip();
    }

    public void Dash(float dashForce)
    {
        Vector3 Direction = facingRight ? Vector3.right: Vector3.left; //change to player's direction based on player's facing direction
        charRigid.AddForce(Direction * dashForce); //add force to the player
    }

    private void Flip()
    {
        //flip character
        facingRight = !facingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        //rotate attack point
        attackPoint.Rotate(0f, 180f, 0f);
    }
}
