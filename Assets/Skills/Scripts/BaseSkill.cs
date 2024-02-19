using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSkill : ScriptableObject
{
    public string name;
    public int damage;
    public float cooldown;
    // Start is called before the first frame update
    public virtual void Activate(PlayerSkill owner){}
}
