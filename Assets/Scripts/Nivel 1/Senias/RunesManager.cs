using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunesManager : MonoBehaviour
{
    public static RunesManager Instance { get; private set; }
    public int cantidad;
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
        RunesManager.Instance.cantidad = 0;
    }

    public void Aumentar() {
        RunesManager.Instance.cantidad += 1;
    }

    public void Reiniciar() {
        RunesManager.Instance.cantidad = 0;
    }


}
