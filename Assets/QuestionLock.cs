using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionLock : MonoBehaviour
{
    [SerializeField] ScriptableOptions scriptableChecking;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (scriptableChecking.AreAllActive(RunesManager.Instance.savedRunes))
            {
                PuzzleGameManager._instance.SelectOption();
            }
        }
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
}
