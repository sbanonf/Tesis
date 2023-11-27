using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateManager : MonoBehaviour
{
    public static ValidateManager _instance;

    public List<bool> validationList = new List<bool>();


    private void Awake()
    {
        _instance = this;
    }

    public void Initialize(int size)
    {
        for(int i = 0; i < size; i++)
        {
            validationList.Add(false);
        }
    }

    public void Validation(int index, bool response)
    {
        validationList[index] = response;

        int validationChecker = 0;

        for(int i = 0; i < validationList.Count; i++)
        {
            if (validationList[i])
                validationChecker++;
        }
        
        if(validationChecker == validationList.Count)
        {
            GenealogicScriptableList._instance.FinishOption();
            OptionsManager._instance.FinishTask();
            print("EVERYTHING IS FINE, YOU DID IT!");
        }
    }

    public void CleanValidateManager()
    {
        validationList.Clear();
    }
}
