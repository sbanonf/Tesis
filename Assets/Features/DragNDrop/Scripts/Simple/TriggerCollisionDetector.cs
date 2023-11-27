using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCollisionDetector : MonoBehaviour
{
    public DND_Symbol_Type targetSymbol;
    public int index;
    Coroutine currentCoroutine = null;
    public bool isTriggered = false;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        CheckSymbolSelector(collision, true);
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        CheckSymbolSelector(collision, false);
    }

    protected void CheckSymbolSelector(Collider2D _, bool isEntering)
    {
        if(_ != null && isEntering)
        {
            print("IS ENTERING");
            DND_Symbol_State temp = _.gameObject.GetComponent<SymbolSelectable>().SymbolState;
            print("" + temp);
            if (temp == DND_Symbol_State.Active)
            {
                print("CALLING");
                ValidateManager._instance.Validation(index, targetSymbol == _.gameObject.GetComponent<SymbolSelectable>().SymbolType);
            }
        }
        else
        {
            isTriggered = false;
            ValidateManager._instance.Validation(index, false);
        }
    }
}
