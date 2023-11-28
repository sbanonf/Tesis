using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Senia Puzzle Options", menuName = "Senias/PuzzleOptions")]
public class ScriptableOptions : ScriptableObject
{
    public List<ScriptablePuzzle> scriptableOption = new List<ScriptablePuzzle>();

    public bool isFinished = false;

    public bool AreAllActive(List<ScriptablePuzzle> _)
    {
        if (_.Count != scriptableOption.Count)
            return false;

        int sum = 0;

        for (int i = 0; i < _.Count; i++)
        {
            if (scriptableOption.Contains(_[i]))
                sum++;
        }


        //for (int i = 0; i < scriptableOption.Count; i++)
        //{
        //    if(scriptableOption[i].Activo)
        //        sum++;
        //}

        return sum == scriptableOption.Count;
    }
}
