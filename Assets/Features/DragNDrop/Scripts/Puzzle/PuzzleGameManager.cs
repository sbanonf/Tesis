using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGameManager : MonoBehaviour
{
    [SerializeField] PuzzleManager puzzleManager;

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
