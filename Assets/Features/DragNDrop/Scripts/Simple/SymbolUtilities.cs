using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SymbolUtilities
{
    static int numberOfChars = 27;

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
        for (int i = 0; i < numberOfChars; i++)
        {
            temp.Add(GetStringFromSymbol((DND_Symbol_Type)i), (DND_Symbol_Type)i);
        }

        int z2Index = 48;

        temp.Add(GetStringFromSymbol((DND_Symbol_Type)z2Index), (DND_Symbol_Type)z2Index);


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

    public static string GetStringFromSymbol(DND_Symbol_Type _)
    {
        if (_ == DND_Symbol_Type.N_)
            return "Ñ";
        else if (_ == DND_Symbol_Type.Z_)
            return "Z1";
        else
            return "" + _;
    }

    public static Dictionary<DND_Symbol_Type, string> InitializeSymbolToString()
    {
        Dictionary<DND_Symbol_Type, string> temp = new Dictionary<DND_Symbol_Type, string>();
        for (int i = 0; i < numberOfChars; i++)
        {
            temp.Add((DND_Symbol_Type)i, GetStringFromSymbol((DND_Symbol_Type)i));
        }

        int z2Index = 48;
        temp.Add((DND_Symbol_Type)z2Index, GetStringFromSymbol((DND_Symbol_Type)z2Index));

        return temp;
    }

    public static string ParsedSymbol(Dictionary<DND_Symbol_Type, string> symbolDictionary, DND_Symbol_Type search)
    {
        string temp;
        if (symbolDictionary.TryGetValue(search, out temp))
        {
            return temp;
        }

        return "A";
    }
}
