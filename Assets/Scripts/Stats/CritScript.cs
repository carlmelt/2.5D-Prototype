using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CritScript : MonoBehaviour
{
    public PlayerInput playerInput;
    [Range(0f, 1f)]  public float critChance;


    private void Update()
    {
        if (playerInput.actions["Attack"].triggered)
        {
            float critRoll = Random.Range(0f, 1f);

            if(critRoll <= critChance)
            {
                Debug.Log("Critical Hit!");
            }else
            {
                Debug.Log("Normal Hit");
            }
            Debug.Log(critRoll);
            Debug.Log(critChance);
        }
    }
}
