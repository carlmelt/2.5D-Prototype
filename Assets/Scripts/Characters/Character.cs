using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/Character")]

public class Character : CharacterStats
{
    public Sprite miniModel;
    public Sprite Illustration;
    public int Energy = 100;
    public float energyRecovery = 0.2f;
    public float experiencePoint = 0;
}
