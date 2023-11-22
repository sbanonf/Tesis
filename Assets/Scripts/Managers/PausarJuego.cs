using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausarJuego : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject menuPausaUI;
    public GameObject canva;
    public GameObject pokemon;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JuegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Reanudar()
    {
        menuPausaUI.SetActive(false);
        canva.SetActive(true);
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    public void Pausar()
    {
        menuPausaUI.SetActive(true);
        canva.SetActive(false);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void CargarMenuPrincipal()
    {
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }

    public void ReanudarJuego()
    {
        Reanudar();
    }
}
