using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public GameObject playerModel;
    private Rigidbody rb;
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
        }
        else
        {
            anim.SetBool("isRun", false);
        }
    }

    void Run()
    {
        
    }
}
