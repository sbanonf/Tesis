using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManagerUI_Puzzle : MonoBehaviour
{
    [SerializeField] private List<string> possibleWords = new List<string>();

    [SerializeField] private List<PuzzleSlot> slots = new List<PuzzleSlot>();

    [SerializeField] private List<DraggableSign> draggableOptions = new List<DraggableSign>();

    private Dictionary<string, DND_Symbol_Type> symbolDictionary = new Dictionary<string, DND_Symbol_Type>();


    public void Initialize()
    {
        symbolDictionary = SymbolUtilities.Initialize();
        List<DND_Symbol_Type> splitted = SymbolUtilities.SplitSymbol(symbolDictionary, possibleWords[0].ToUpper());

        // Initialize Targets/Slots
        //List<DND_Symbol_Type> splitted = _.correctSymbols;
        for (int i = 0; i < slots.Count; i++)
            slots[i].gameObject.SetActive(false);

        for (int i = 0; i < splitted.Count; i++)
        {
            slots[i].gameObject.SetActive(true);
            slots[i].InitializeTargetSymbol(splitted[i], i);
        }

        for (int i = 0; i < draggableOptions.Count; i++)
            draggableOptions[i].gameObject.SetActive(false);

        // Initialize Options
        //List<CharSettings> charSettings = _.ShuffleCharSettings();
        //for (int i = 0; i < charSettings.Count; i++)
        //{
        //    CharSettings setting = charSettings[i];
        //    draggableOptions[i].gameObject.SetActive(true);
        //    draggableOptions[i].InitializeDraggableOption(setting.type, setting.sprite);
        //}

        ValidateManager_Puzzle._instance.Initialize(splitted.Count);
    }

    public void Reset()
    {
        for (int i = 0; i < draggableOptions.Count; i++)
        {
            draggableOptions[i].ResetDraggable();
        }
    }
}
