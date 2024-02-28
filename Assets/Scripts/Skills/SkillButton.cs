using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillButton : MonoBehaviour
{
    // Start is called before the first frame update
    public BaseSkill skill;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillDamage;

    //skill preview video
    // public GameObject skillPreview;

    void Start()
    {
        //access child that has object name "SkillName"
        // skillName = transform.FindChild("SkillName").GetComponent<TextMeshProUGUI>();
        skillName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(skill != null){
            _update_button();
            // skillDamage.text = skill.damage.ToString();
        }
    }

    public void _update_button(){ // update button info
        skillName.text = skill.name;
    }
}
