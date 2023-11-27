using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class PuzzleSlot : BaseSlot
{
    [SerializeField] private DND_Symbol_Type _symbolType;
    [SerializeField] int index;
    [SerializeField] TextMeshProUGUI textMesh;


    protected override void ValidateOnDrop(DraggableSign_Puzzle draggableSign)
    {
        print("CALL VALIDATE ON DROP");
        DND_Symbol_Type symbolType = draggableSign.SymbolType;
        CheckTargetSymbol(symbolType);
    }

    public void CheckTargetSymbol(DND_Symbol_Type symbolType)
    {
        ValidateManager_Puzzle._instance.Validation(index, symbolType == _symbolType);
    }

    public void InitializeTargetSymbol(DND_Symbol_Type _symbol, int _index)
    {
        _symbolType = _symbol;
        index = _index;
        textMesh.text = StringToDNDManager._instance.GetLetter(_symbol);
    }
}
