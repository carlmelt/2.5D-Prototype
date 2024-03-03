using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{

  public void Startbtn()
  {
    SceneManager.LoadScene("Skill");
  }
  public void SkillBtn()
  {
    SceneManager.LoadScene("Menu");
  }
}
