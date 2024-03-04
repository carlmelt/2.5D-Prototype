using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    /*============================================NOTES============================================
    This script is responsible for containing the player's components and properties. 
    It is also responsible for handling the player's stats and skills.
    
    */
    public PlayerController playerController;
    public PlayerContainer playerContainer;
    //public StatModifier statMod;

    void Start()
    {
        ResetCooldown();
    }

    public void ResetCooldown()
    {
        playerContainer.skill1.isCooldown = false;
        playerContainer.skill2.isCooldown = false;
        playerContainer.ultimateSkill.isCooldown = false;
        playerContainer.dashSkill.isCooldown = false;
    }

}
