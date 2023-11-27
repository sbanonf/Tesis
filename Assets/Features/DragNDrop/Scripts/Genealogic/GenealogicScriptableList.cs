using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenealogicScriptableList : MonoBehaviour
{
    public static GenealogicScriptableList _instance;

    [SerializeField] private List<ScriptableFamiliarCardInfo> possibleOptions = new List<ScriptableFamiliarCardInfo>();
    [SerializeField] int selectedCharacter = -1;
    public int SelectedCharacter => selectedCharacter;


    private void Awake()
    {
        _instance = this;
    }

    public void SelectCharacter(OptionButton optionButton)
    {
        print("CALL SELECT CHARACTER");
        for (int i = 0; i < possibleOptions.Count; i++)
        {
            if (optionButton.GetGenealogicType() == possibleOptions[i].genealogicType)
            {
                selectedCharacter = i;
                print("CALL SELECT CHARACTER");
                break;
            }
        }
    }

    public List<ScriptableFamiliarCardInfo> GetPossibleOptions()
    {
        return possibleOptions;
    }

    public ScriptableFamiliarCardInfo GetSelectedOption()
    {
        print("SELECTED Character: " + selectedCharacter);
        return possibleOptions[selectedCharacter];
    }

    public ScriptableFamiliarCardInfo GetSelectedOption(OptionButton optionButton)
    {
        SelectCharacter(optionButton);
        return possibleOptions[selectedCharacter];
    }

    public void FinishOption()
    {
        possibleOptions[selectedCharacter].isFinished = true;
    }
}
