using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PuzzleOption
{
    public Sprite sprite;
    public int index;
    public DND_Symbol_Type type;
    public string uniqueId;

    public PuzzleOption(Sprite _sprite, int _index, DND_Symbol_Type _type, string _uniqueId="")
    {
        sprite = _sprite;
        index = _index;
        type = _type;
        uniqueId = _uniqueId != "" ? _uniqueId : "" + type + index;
    }
}

public class SlotsManagerUI_Puzzle : MonoBehaviour
{
    [SerializeField] private List<string> possibleWords = new List<string>();

    [SerializeField] private List<PuzzleSlot> slots = new List<PuzzleSlot>();

    [SerializeField] private List<DraggableSign_Puzzle> draggableOptions = new List<DraggableSign_Puzzle>();
    [SerializeField] private List<BaseSlot> baseSlots = new List<BaseSlot>();

    private Dictionary<string, DND_Symbol_Type> symbolDictionary = new Dictionary<string, DND_Symbol_Type>();

    [SerializeField] private List<ScriptablePuzzle> puzzleOption = new List<ScriptablePuzzle>();

    [SerializeField] List<ScriptableOptions> options=new List<ScriptableOptions>();
    [SerializeField] List<QuestionLock> levelLocks = new List<QuestionLock>();

    [SerializeField] private int index = 0;
    
    public void Initialize()
    {
        symbolDictionary = SymbolUtilities.Initialize();
        List<DND_Symbol_Type> splitted = SymbolUtilities.SplitSymbol(symbolDictionary, possibleWords[index].ToUpper());

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
        {
            draggableOptions[i].gameObject.SetActive(false);
            baseSlots[i].gameObject.SetActive(false);
        }

        // Initialize Options
        //List<CharSettings> charSettings = _.ShuffleCharSettings();
        //List<ScriptablePuzzle> temp = ListExtend.ShuffleList(puzzleOption);
        List<ScriptablePuzzle> temp = ListExtend.ShuffleList(options[index].scriptableOption);
        for (int i = 0; i < temp.Count; i++)
        {
            ScriptablePuzzle tempScriptable = temp[i];
            if (tempScriptable.Activo)
            {
                PuzzleOption setting = new PuzzleOption(tempScriptable.img, i, tempScriptable.type);
                baseSlots[i].gameObject.SetActive(true);
                draggableOptions[i].gameObject.SetActive(true);
                draggableOptions[i].InitializeDraggableOption(setting.type, setting.sprite);
            }
        }

        ValidateManager_Puzzle._instance.Initialize(splitted.Count);
    }

    public void Reset()
    {
        options[index].isFinished = true;
        levelLocks[index].TurnOff();
        if (RunesManager.Instance != null)
            RunesManager.Instance.CleanRunes();
        for (int i = 0; i < draggableOptions.Count; i++)
        {
            draggableOptions[i].ResetDraggable();
        }
    }

    public void UpdateIndex()
    {
        index++;
    }
}
