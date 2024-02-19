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
    public bool canDash = true;
public Transform attackPoint;
    public PlayerSkill playerSkill;

    private void Awake()
    {
        charRigid = GetComponent<Rigidbody>();
        playerSkill = GetComponent<PlayerSkill>();
    }

    public void Move(Vector2 move)
    {
        Vector3 targetVelocity = new Vector3(move.x, charRigid.velocity.y, move.y);
        charRigid.velocity = Vector3.SmoothDamp(charRigid.velocity, targetVelocity, ref m_Velocity, m_movementSmoother);

        if (move.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (move.x < 0 && facingRight)
        {
            Flip();
        }

    }

    public void Dash()
    {

        //Check left or right
        if (canDash)
        {
            canDash = false;
            if (facingRight)
            {
                charRigid.AddForce(Vector3.right * 500);
            }
            else
            {
                charRigid.AddForce(Vector3.left * 500);
            }
            StartCoroutine(DashCooldown(1f));
        }
    }

    void Skill()
    {
        playerSkill.Skill();
    }

    IEnumerator DashCooldown(float Cd)
    {
        yield return new WaitForSeconds(Cd);
        Debug.Log("Dash Ready");
        canDash = true;
    }
    // {
    //     float cooldownTime = 0;
    //     cooldownTime += Time.fixedDeltaTime;
    //     if (cooldownTime > Cd)
    //     {
    //         canDash = true;
    //     }
    // }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        //rotate attack point
        attackPoint.Rotate(0f, 180f, 0f);
    }
}
