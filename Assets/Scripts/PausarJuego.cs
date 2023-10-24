using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausarJuego : MonoBehaviour
{
    public static bool JuegoPausado = false;
    public GameObject menuPausaUI;

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
        Time.timeScale = 1f;
        JuegoPausado = false;
    }

    void Pausar()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        JuegoPausado = true;
    }

    public void CargarMenuPrincipal()
    {
        Time.timeScale = 1f;
        // Código para cargar el menú principal
    }

    public void SalirJuego()
    {
        // Código para salir del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }

    public void ReanudarJuego()
    {
        Reanudar();
    }
}
