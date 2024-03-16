using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsModifier : MonoBehaviour
{
    [SerializeField] CharacterStats characterStats;
    List<StatusEffect> activeEffects = new List<StatusEffect>();

    void Awake(){
        characterStats = GetComponent<CharacterStats>();
    }

    public void AddEffect(StatusEffect effect)
    {
        activeEffects.Add(effect);
        foreach(StatusEffect.affectedStat affectedStats in effect.affectedStatsList){
            
        }
        // effect.ApplyEffect();
    }

    //add effect to owner
    public void RemoveEffect(StatusEffect effect)
    {
        activeEffects.Remove(effect);
        // effect.RemoveEffect();
    }

    public void RemoveAllEffects()
    {
        foreach (StatusEffect effect in activeEffects)
        {
            effect.RemoveEffect();
        }
        activeEffects.Clear();
    }

    public IEnumerator StartEffect(StatusEffect effect, float duration)
    {
        yield return new WaitForSeconds(duration);
        RemoveEffect(effect);
    }

}
