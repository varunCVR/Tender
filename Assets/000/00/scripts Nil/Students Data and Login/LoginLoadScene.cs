using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginLoadScene : MonoBehaviour
{
    
    [Space(20)] 
    [Header("Input Fields")] 
    public List<StudentsStandards> studentsStandardsList;
    
    [Space(20)]
    [Header("Input Fields")]
    public TMP_InputField nameInputField;
    public TMP_InputField rollNumberInputField;
    
    [Space(20)]
    [Header("DropDowns")]
    public TMP_Dropdown stdDropDown;
    public TMP_Dropdown divisionDropDown;
    
    public Divisions division;
    private List<int> studentsStandards;
    private List<string> studentNames;
    private List<string> studentsRollNumber;
    
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            
        }
    }


    public void GetValueOfStandardsDropDown()
    {
        
    }
    public void GetValueOfDivisionDropDown()
    {
        
    }
    public void OnCLick()
    {
        SceneManager.LoadScene("Menu");
    }

    public enum Divisions
    {
        A,B,C,D
    }
}
