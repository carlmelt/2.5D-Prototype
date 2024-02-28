using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSelector : MonoBehaviour
{
    // Start is called before the first frame update
    public static Button selectedButton;
    public static BaseSkill selectedSkill;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void confirm(){
        if(selectedButton != null){
            // selectedSkill = selectedButton.GetComponent<SkillButton>().skill;
            Debug.Log(selectedSkill.name);
        }
    }
}
