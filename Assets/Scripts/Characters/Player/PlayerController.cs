using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Components")]
    private PlayerContainer playerContainer; //Move to player later.
    public AttackController playerAttack;
    public SkillController playerSkill;
    public MovementController playerMovement;
    public Animator playerAnimator;
    public PlayerInput playerInput;

    [Header("Player Conditions")]
    private bool canAttack = true;
    private bool canWalk = true;
    private bool isInvincible = false;
    public bool _isInvincible {
        get => isInvincible;
        set {
             Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), value);
             isInvincible = value;
        }
    }

    [Header("Movement-related vars")]
    private Vector2 playerMove;
    float attackCooldown;
    public float walkSpeed = 40f; //From playerContainer's stats

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        playerContainer = GetComponent<Player>().playerContainer;

    }

    // Start is called before the first frame update
    void Start() { playerSkill.SkillCasted += Freeze; }
    void OnDisable() { playerSkill.SkillCasted -= Freeze; }

    // Update is called once per frame
    void Update()
    {
        DetectInput();
    }

    void FixedUpdate(){
        HandleMove();
    }

    void DetectInput(){
        if (canWalk)
        {
            playerMove = playerInput.actions["Move"].ReadValue<Vector2>();
            playerAnimator.SetBool("isWalking", (Mathf.Abs(playerMove.x) > 0 || (Mathf.Abs(playerMove.y)) > 0));//refactor
        }
        if (playerInput.actions["Attack"].triggered && canAttack)
        { //Attack Button
            attackCooldown = Time.time; //ntar
            canAttack = false;
            //reset walk dir, render walk impossible
            playerMove = Vector2.zero;
            canWalk = false;
            //attack
            playerAttack.Attack(playerAnimator);
        }
        if (playerInput.actions["Dash"].triggered)
        {//Dash Button
            playerSkill.Skill(playerContainer.dashSkill);
            playerAttack.currentCombo = 0;

        }
        if (playerInput.actions["Skill1"].triggered) playerSkill.Skill(playerContainer.skill1);
        if (playerInput.actions["Skill2"].triggered) playerSkill.Skill(playerContainer.skill2);
        
    }

    void HandleMove(){
        playerMovement.Move(new Vector2(playerMove.x, playerMove.y).normalized * walkSpeed * Time.fixedDeltaTime);

        if (Time.time - attackCooldown > 0.3f)
        {
            canAttack = true;
            canWalk = true;
            for (int i = 0; i < 3; i++)
            {
                playerAnimator.ResetTrigger("Attack" + i.ToString());
            }
        }
        if (Time.time - attackCooldown > 0.6f)
        {//reset
            playerAttack.currentCombo = 0;
        }
    }

    void Freeze(float timeOffset=0.3f){
        canWalk = false;
        canAttack = false;
        playerMove = Vector2.zero;
        attackCooldown = Time.time + (timeOffset - 0.3f);  //ntar
    }

    public IEnumerator Invincible(float duration){
        _isInvincible = true;
        yield return new WaitForSeconds(duration);
        _isInvincible = false;
        Debug.Log("Invicible Time Ended");
    }
}
