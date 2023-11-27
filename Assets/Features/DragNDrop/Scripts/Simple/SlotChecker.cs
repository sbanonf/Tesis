using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotChecker : TriggerCollisionDetector
{

    public void InitializeTargetSymbol(Vector3 _pos, DND_Symbol_Type _symbol,int _index)
    {
        transform.position = _pos;
        targetSymbol = _symbol;
        index = _index;
    }

    public void CheckTargetSymbol(DND_Symbol_Type symbolType)
    {
        ValidateManager._instance.Validation(index,symbolType == targetSymbol);
    }
}
