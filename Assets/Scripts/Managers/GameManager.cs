using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isAlive=true;
    public bool isGameFinished = false;

    [SerializeField] GameObject continueMenu;
    //[SerializeField] PlayerController player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);

        continueMenu.SetActive(false);
    }

    public void PlayerIsDeath()
    {
        isAlive = false;
        continueMenu.SetActive(true);
    }

    public void Continue()
    {
      //  player.Continue();
        isAlive = true;
        continueMenu.SetActive(false);
    }
}
