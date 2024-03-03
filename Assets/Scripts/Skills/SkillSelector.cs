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
    public PlayerContainer playerContainer;
    public List<Button> buttons = new List<Button>();
    public bool isUltimate = false;
    void Awake()
    {
        foreach (Transform child in transform)
        {
            Button buttonChild = child.GetComponent<Button>();
            buttonChild.onClick.AddListener(() => select(buttonChild));
            buttons.Add(buttonChild);
        }
    }

    void Start()
    {
        // playerSkillHolder = FindObjectOfType<PlayerMovement>().GetComponent<SkillHolder>(); //If player exist, use this
        // playerSkillHolder = FindObjectOfType<SkillHolder>(); // For testing purpose, when player doesn't exist.
        // playerSkillHolder.skillChanged += UpdateButton;
        //Adjust initial button skill, so they match with player's skill.
        // List<BaseSkill> playerSkills = new List<BaseSkill>(){SkillHolder.skill1, SkillHolder.skill2, SkillHolder.ultimateSkill};


        playerContainer.skillChanged += UpdateButton; //Add listener to skillChanged event
        List<BaseSkill> playerSkills = new List<BaseSkill>() { playerContainer.skill1, playerContainer.skill2, playerContainer.ultimateSkill };
        for (int i = 0; i < buttons.Count; i++)
        {
            if (playerSkills[i] != null) UpdateButton(i, playerSkills[i]);

        }
    }

    void OnDisable()
    {

        playerContainer.skillChanged -= UpdateButton;
    }

    void UpdateButton(int buttonIndex, BaseSkill buttonSkill)
    {
        buttons[buttonIndex].GetComponent<SkillButton>().skill = buttonSkill;
    }

    void select(Button btn)
    {
        // ColorBlock btnColor = btn.colors;
        // if (selectedButton != null){
        //     btnColor.normalColor = Color.white;
        //     selectedButton.colors = btnColor;
        // }

        // btnColor.normalColor = Color.grey;
        // btn.colors = btnColor;
        if (selectedButton != null)
        { // If there is already selected button, do:
            SkillButton selectedSkillButton = selectedButton.GetComponent<SkillButton>(); //get reference to skillbutton
            selectedSkillButton.isSelected = false; // then set selected to false
        }
        btn.GetComponent<SkillButton>().isSelected = true; // The CURRENTLY selected button's isSelected will be set to true, thus darken it 
        selectedButton = btn; //Then the currently selected button will be stored to selectedButton variable, so it can be deselected later.

        if (selectedButton.name == "Ultimate")
        {
            isUltimate = true;
        }
        else
        {
            isUltimate = false;
        }
    }
}
