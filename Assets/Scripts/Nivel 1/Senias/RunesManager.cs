using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunesManager : MonoBehaviour
{
    public static RunesManager Instance { get; private set; }
    public int cantidad;

    public List<ScriptablePuzzle> savedRunes = new List<ScriptablePuzzle>();

    [SerializeField] int countRunes;
    public int CountRunes => countRunes;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    private void Start()
    {
        cantidad = 0;
    }

    public void Aumentar() {
        cantidad += 1;
    }

    public void Reiniciar() {
        cantidad = 0;
    }

    public void SaveRune(ScriptablePuzzle _)
    {
        savedRunes.Add(_);
    }

    public void CountRuneUnits()
    {
        countRunes++;
    }

    public void CleanRunes()
    {
        savedRunes.Clear();
    }
}
