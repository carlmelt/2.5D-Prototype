using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkillButton : MonoBehaviour
{
    // Start is called before the first frame update
    public BaseSkill skill;
    public TextMeshProUGUI skillName;
    public TextMeshProUGUI skillDamage;
    public GameObject selectedOverlay;
    bool _isSelected;
    public bool isSelected{
        get => _isSelected;
        set {
            selectedOverlay?.SetActive(value);
            _isSelected = value;
        }
    }

    //skill preview video
    // public GameObject skillPreview;

    void Start()
    {
        //access child that has object name "SkillName"
        // skillName = transform.FindChild("SkillName").GetComponent<TextMeshProUGUI>();
        skillName = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        isSelected = false;
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
        skillName.text = skill.skillName;
    }
}
