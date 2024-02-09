using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerCombo : MonoBehaviour
{
    public Animator playerAnimator;
    [SerializeField] private int comboCount = 3;
    public int currentCombo = 0;
    
    public void Attack(){//refactor
        playerAnimator.SetTrigger("Attack"+currentCombo.ToString());
        currentCombo += 1;
        if (currentCombo >= comboCount) currentCombo = 0;
    }
}
