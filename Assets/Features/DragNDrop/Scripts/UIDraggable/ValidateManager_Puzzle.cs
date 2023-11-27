using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateManager_Puzzle : MonoBehaviour
{
    public static ValidateManager_Puzzle _instance;

    public List<bool> validationList = new List<bool>();
    [SerializeField] PopUp levelPopUp;

    private void Awake()
    {
        _instance = this;
    }

    public void Initialize(int size)
    {
        for (int i = 0; i < size; i++)
        {
            validationList.Add(false);
        }
    }

    public void Validation(int index, bool response)
    {
        validationList[index] = response;

        int validationChecker = 0;

        for (int i = 0; i < validationList.Count; i++)
        {
            if (validationList[i])
                validationChecker++;
        }

        if (validationChecker == validationList.Count)
        {
            levelPopUp.TurnOn();
        }
    }

    public void CleanValidateManager()
    {
        validationList.Clear();
    }

    public void ResetLevelPopUp()
    {
        levelPopUp.Reset();
    }
}
