using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManagerUI : MonoBehaviour
{
    //[SerializeField] private List<ScriptableFamiliarCardInfo> possibleOptions = new List<ScriptableFamiliarCardInfo>();
    [SerializeField] private List<ItemSlot> slots = new List<ItemSlot>();

    //private Dictionary<string, DND_Symbol_Type> symbolDictionary = new Dictionary<string, DND_Symbol_Type>();

    [SerializeField] private List<DraggableSign> draggableOptions = new List<DraggableSign>();

    public void Initialize()
    {
        ScriptableFamiliarCardInfo _ = GenealogicScriptableList._instance.GetSelectedOption();

        // Initialize Targets/Slots
        List<DND_Symbol_Type> splitted = _.correctSymbols;
        for(int i = 0; i < slots.Count; i++)
            slots[i].gameObject.SetActive(false);

        for (int i = 0; i < splitted.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].InitializeTargetSymbol(splitted[i], i);
        }

        for (int i = 0; i < draggableOptions.Count; i++)
            draggableOptions[i].gameObject.SetActive(false);

        // Initialize Options
        List<CharSettings> charSettings = _.ShuffleCharSettings();
        for(int i=0;i< charSettings.Count; i++)
        {
            CharSettings setting = charSettings[i];
            draggableOptions[i].gameObject.SetActive(true);
            draggableOptions[i].InitializeDraggableOption(setting.type, setting.sprite);
        }

        ValidateManager._instance.Initialize(splitted.Count);
    }

    public void Reset()
    {
        for (int i = 0; i < draggableOptions.Count; i++)
        {
            draggableOptions[i].ResetDraggable();
        }
    }

}
