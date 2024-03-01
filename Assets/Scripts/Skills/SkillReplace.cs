using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillReplace : MonoBehaviour
{
    public static BaseSkill selectedSkill;
    SkillButton selectedSkillButton;
    public PlayerContainer playerContainer; //for testing purpose. use reference to selected player in real use.
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
        ClearSelection(selectedSkillButton);
        selectedSkillButton = btn.gameObject.GetComponent<SkillButton>();
        selectedSkillButton.isSelected = true;
        selectedSkill = selectedSkillButton.skill;
        // if (selectedSkill.name == "Ultimate"){
        //     isUltimate = true;
        // }
        // else{
        //     isUltimate = false;
        // }
    }

    void ClearSelection(SkillButton targetButton){
        if (targetButton != null){
            targetButton.isSelected = false;
        }
    }

    public void Replace(){
        // SkillHolder playerSkill = FindObjectOfType<PlayerMovement>().GetComponent<SkillHolder>(); // Use this if player exist.
        // SkillHolder playerSkill = FindObjectOfType<SkillHolder>();
        BaseSkill selectedButtonSkill = SkillSelector.selectedButton.GetComponent<SkillButton>().skill;
        // if (playerSkill != null) playerSkill.ChangeSkill(selectedButtonSkill, selectedSkill);
        if (playerContainer != null) playerContainer.ChangeSkill(selectedButtonSkill, selectedSkill);
        ClearSelection(selectedSkillButton);
        // ClearSelection(SkillSelector.selectedButton.GetComponent<SkillButton>());
    }
}
