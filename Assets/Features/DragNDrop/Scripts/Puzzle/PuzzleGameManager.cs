using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    public static PuzzleGameManager _instance;
    [SerializeField] PuzzleManager puzzleManager;


    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        puzzleManager.Initialize();
    }

    public void SelectOption()
    {
        puzzleManager.Select();
    }

    public void CloseOption()
    {
        puzzleManager.Close();
    }
}
