using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static Button selectedButton;
    public SkillHolder playerSkillHolder;
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

    void Start(){
        // playerSkillHolder = FindObjectOfType<PlayerMovement>().GetComponent<SkillHolder>(); //If player exist, use this
        playerSkillHolder = FindObjectOfType<SkillHolder>(); // For testing purpose, when player doesn't exist.
        playerSkillHolder.skillChanged += UpdateButton;
        //Adjust initial button skill, so they match with player's skill.
        List<BaseSkill> playerSkills = new List<BaseSkill>(){SkillHolder.skill1, SkillHolder.skill2, SkillHolder.ultimateSkill};
        for (int i = 0; i < buttons.Count; i++){
            if(playerSkills[i] != null) UpdateButton(i, playerSkills[i]);
            Debug.Log(playerSkills[i]);
            Debug.Log(buttons[i]);
        }
    }

    void OnDisable(){
        playerSkillHolder.skillChanged -= UpdateButton;
    }

    void UpdateButton(int buttonIndex, BaseSkill buttonSkill){
        buttons[buttonIndex].GetComponent<SkillButton>().skill = buttonSkill;
    }

    void select(Button btn){
        // ColorBlock btnColor = btn.colors;
        // if (selectedButton != null){
        //     btnColor.normalColor = Color.white;
        //     selectedButton.colors = btnColor;
        // }

        // btnColor.normalColor = Color.grey;
        // btn.colors = btnColor;
        if (selectedButton != null){
            SkillButton selectedSkillButton = selectedButton.GetComponent<SkillButton>();
            selectedSkillButton.isSelected = false;
        }
        btn.GetComponent<SkillButton>().isSelected = true;
        selectedButton = btn;

        if (selectedButton.name == "Ultimate"){
            isUltimate = true;
        }
        else{
            isUltimate = false;
        }
    }
}
