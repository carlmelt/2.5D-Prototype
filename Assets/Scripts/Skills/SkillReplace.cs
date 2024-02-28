using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillReplace : MonoBehaviour
{
    public static BaseSkill selectedSkill;
    public List<Button> buttons = new List<Button>();
    public bool isUltimate = false;
    void Awake()
    {
        foreach(Transform child in transform){
            Button buttonChild = child.GetComponent<Button>();
            buttonChild.onClick.AddListener(()=>select(buttonChild));
            buttons.Add(buttonChild);
        }
    }

    void select(Button btn){
        selectedSkill = btn.gameObject.GetComponent<SkillButton>().skill;
        // if (selectedSkill.name == "Ultimate"){
        //     isUltimate = true;
        // }
        // else{
        //     isUltimate = false;
        // }
    }

    public void Replace(){
        // SkillHolder playerSkill = FindObjectOfType<PlayerMovement>().GetComponent<SkillHolder>(); // Use this if player exist.
        SkillHolder playerSkill = FindObjectOfType<SkillHolder>();
        if (playerSkill != null) playerSkill.ChangeSkill(SkillSelector.selectedButton.GetComponent<SkillButton>().skill, selectedSkill);

    }
}
