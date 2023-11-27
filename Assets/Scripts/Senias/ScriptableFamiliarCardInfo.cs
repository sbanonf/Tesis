using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharSettings
{
    public Sprite sprite;
    public int index;
    public DND_Symbol_Type type;
}

[CreateAssetMenu(fileName = "New Familiar Info", menuName = "Senias/FamiliarInfoSenia")]
public class ScriptableFamiliarCardInfo : ScriptableObject
{
    public Genealogic_Type genealogicType;
    public Sprite cardSprite;
    public string cardName;

    public List<CharSettings> charSettings = new List<CharSettings>();
    public bool isFinished = false;

    public List<DND_Symbol_Type> correctSymbols = new List<DND_Symbol_Type>();

    public List<CharSettings> ShuffleCharSettings()
    {
        List<CharSettings> tempShuffleList = new List<CharSettings>();
        List<int> temp = new List<int>();

        for(int i = 0; i < charSettings.Count; i++)
        {
            temp.Add(i);
        }

        tempShuffleList = ShuffleList(charSettings);

        return tempShuffleList;
    }

    public List<T> ShuffleList<T>(List<T> list)
    {
        List<T> _list = list;
        System.Random random = new System.Random();
        int n = _list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T temp = _list[k];
            _list[k] = _list[n];
            _list[n] = temp;
        }

        return _list;
    }
}
