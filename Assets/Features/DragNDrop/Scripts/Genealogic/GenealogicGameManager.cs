using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenealogicGameManager : MonoBehaviour
{
    [SerializeField] GenealogicManager genealogicManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        genealogicManager.Initialize();
        OptionsManager._instance.Initialize();
    }

    public void SelectOption(OptionButton optionButton)
    {
        OptionsManager._instance.SelectOption(optionButton);
        genealogicManager.Select();
    }

    public void CloseOption()
    {
        genealogicManager.Close();
    }
}
