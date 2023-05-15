using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisparadorCine : MonoBehaviour
{
    public string escena;
    private void Awake()
    {
        SceneManager.LoadScene(escena);
    }
}
