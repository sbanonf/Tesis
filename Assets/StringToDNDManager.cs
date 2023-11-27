using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringToDNDManager : MonoBehaviour
{
    public static StringToDNDManager _instance;
    Dictionary<DND_Symbol_Type, string> letterDictionary = new Dictionary<DND_Symbol_Type, string>();

    private void Awake()
    {
        _instance = this;
        letterDictionary = SymbolUtilities.InitializeSymbolToString();
    }

    public string GetLetter(DND_Symbol_Type _)
    {
        return SymbolUtilities.ParsedSymbol(letterDictionary, _);
    }

}
