using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionButton : MonoBehaviour
{
    [SerializeField] ScriptableFamiliarCardInfo scriptable;

    [SerializeField] Image img;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Button button;
    [SerializeField] GameObject check;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        img.sprite = scriptable.cardSprite;
        text.text = scriptable.cardName;
        check.SetActive(false);
    }

    public void FinishTask()
    {
        Debug.Log(gameObject.name);
        Debug.Log("CALL STUFF " + scriptable.isFinished);
        if (scriptable.isFinished)
        {
            button.interactable = false;
            check.SetActive(true);
        }
    }

    public Genealogic_Type GetGenealogicType()
    {
        return scriptable.genealogicType;
    }
}
