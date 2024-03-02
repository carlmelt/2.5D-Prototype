using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public GameObject playerModel;
    private Rigidbody rb;
    private bool isRun;
    public Transform attackPoint;
    
    public float attackRange = 0.5f;
    // Start is called before the first frame update
    void Awake()
    {
        playerModel = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        anim = playerModel.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveVelocity = new Vector3(moveX, 0, moveZ).normalized * 5f;
        rb.velocity = moveVelocity;
        Debug.Log(moveVelocity);
        if (moveX != 0 || moveZ != 0)
        {
            anim.SetBool("isRun", true);
            isRun = true;
        }
        else
        {
            anim.SetBool("isRun", false);
            isRun = false;
        }

        Attack();   
    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isRun == false)
        {
            anim.SetTrigger("attack");
            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange); //area will spawn when attack button is pressed   
            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("We hit " + enemy.name);
            }
        }
    }

     void OnDrawGizmosSelected() {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
