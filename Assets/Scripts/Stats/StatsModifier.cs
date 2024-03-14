using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsModifier : MonoBehaviour
{
   
   List<StatusEffect> activeEffects = new List<StatusEffect>();

    public void AddEffect(StatusEffect effect)
    {
         activeEffects.Add(effect);
         effect.ApplyEffect();
    }

    //add effect to owner
    public void RemoveEffect(StatusEffect effect)
    {
        activeEffects.Remove(effect);
        effect.RemoveEffect();
    }

    public void RemoveAllEffects()
    {
        foreach (StatusEffect effect in activeEffects)
        {
            effect.RemoveEffect();
        }
        activeEffects.Clear();
    }

}
