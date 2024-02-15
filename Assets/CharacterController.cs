using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class _CharacterController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 500f;
    [Range(0, .3f)][SerializeField] private float m_movementSmoother = .05f;
    private Rigidbody charRigid;
    private bool facingRight = true;
    private Vector3 m_Velocity = Vector3.zero;

    private void Awake(){
        charRigid = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 move){
        Vector3 targetVelocity = new Vector3(move.x, charRigid.velocity.y, move.y);
        charRigid.velocity = Vector3.SmoothDamp(charRigid.velocity, targetVelocity, ref m_Velocity, m_movementSmoother);

        if(move.x > 0 && !facingRight){
            Flip();
        }
        else if(move.x < 0 && facingRight){
            Flip();
        }

    }

    private void Flip(){
        facingRight = !facingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
    }
}
