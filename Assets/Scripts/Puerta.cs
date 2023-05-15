using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        RunesManager.Instance.Reiniciar();
        if (collision.gameObject.CompareTag("Player")) {
            LevelManager.Instance.LoadScene(sceneName);
        }

    }
}
