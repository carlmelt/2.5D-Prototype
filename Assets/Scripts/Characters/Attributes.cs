using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attributes
{
    public string attributeName;
    public float value;

    public Attributes(string _name, float baseValue){
        attributeName = _name;
        value = baseValue;
    }
}
