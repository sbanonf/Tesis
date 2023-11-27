using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtend
{
    public static List<T> ShuffleList<T>(List<T> list)
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
