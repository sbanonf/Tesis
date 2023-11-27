using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : BaseSlot
{
    [SerializeField] private DND_Symbol_Type _symbolType;
    [SerializeField] int index;


    protected override void ValidateOnDrop(DraggableSign draggableSign)
    {
        DND_Symbol_Type symbolType = draggableSign.SymbolType;
        CheckTargetSymbol(symbolType);
    }

    public void CheckTargetSymbol(DND_Symbol_Type symbolType)
    {
        ValidateManager._instance.Validation(index, symbolType == _symbolType);
    }

    public void InitializeTargetSymbol(DND_Symbol_Type _symbol, int _index)
    {
        _symbolType = _symbol;
        index = _index;
    }
}
