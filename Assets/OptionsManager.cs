using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public static OptionsManager _instance;
    [SerializeField] List<OptionButton> optionButtons = new List<OptionButton>();
    [SerializeField] int selectedOption = -1;
    public int SelectedOption => selectedOption;



    private void Awake()
    {
        _instance = this;
    }

    public void Initialize()
    {
        for(int i = 0; i < optionButtons.Count; i++)
        {
            optionButtons[i].Initialize();
        }
    }

    public void SelectOption(OptionButton optionButton)
    {
        for(int i = 0; i < optionButtons.Count; i++)
        {
            if(optionButton.GetGenealogicType() == optionButtons[i].GetGenealogicType())
            {
                selectedOption = i;
                break;
            }
        }
        GenealogicScriptableList._instance.SelectCharacter(optionButton);
    }

    public void FinishTask(int option)
    {
        optionButtons[option].FinishTask();
    }

    public void FinishTask()
    {
        optionButtons[selectedOption].FinishTask();
    }


    public void ResetOption()
    {
        selectedOption = -1;
    }
}
