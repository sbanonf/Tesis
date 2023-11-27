using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SymbolUtilities
{
    public static List<DND_Symbol_Type> SplitSymbol(Dictionary<string, DND_Symbol_Type> symbolDictionary, string word)
    {
        List<DND_Symbol_Type> temp = new List<DND_Symbol_Type>();
        List<string> wordList = new List<string>();

        for (int i = 0; i < word.Length; i++)
        {
            wordList.Add(word[i].ToString());
        }

        for (int i = 0; i < wordList.Count; i++)
        {
            temp.Add(ParsedSymbol(symbolDictionary, wordList[i]));
        }

        return temp;
    }

    public static Dictionary<string, DND_Symbol_Type> Initialize()
    {
        Dictionary<string, DND_Symbol_Type> temp = new Dictionary<string, DND_Symbol_Type>();

        // A - Z
        for (int i = 0; i < 27; i++)
        {
            temp.Add("" + (DND_Symbol_Type)i, (DND_Symbol_Type)i);
        }

        return temp;
    }

    public static DND_Symbol_Type ParsedSymbol(Dictionary<string, DND_Symbol_Type> symbolDictionary, string search)
    {

        DND_Symbol_Type temp;
        if (symbolDictionary.TryGetValue(search, out temp))
        {
            return temp;
        }

        return DND_Symbol_Type.A;
    }
}
