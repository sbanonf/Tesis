using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PeleaManager : MonoBehaviour
{
    public Slider mSlider;
    public static PeleaManager Instance;
    public ScriptablePregunta[] preguntas;
    public Image imagenPadre;
    public GameObject prefab;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        mSlider.value = mSlider.maxValue / 2;
        InvokeRepeating("Disminuir", 0f, 4f);
        Seteo();
    }


    public void Seteo()
    {
        int preguntarandom= Random.Range(0, preguntas.Length);
        prefab.GetComponent<SO_SetearPregunta>().pregunta = preguntas[preguntarandom];
        GameObject objeton = Instantiate(prefab, imagenPadre.transform);
    }

    private void Update()
    {
        if (mSlider.value <= mSlider.minValue)
        {
            //Murio;
        }
        else if (mSlider.value >= mSlider.maxValue) { 
           //Gano
        }
    }
    public void Disminuir() {
        mSlider.value--;
    }
    public void Aumentar() {
        mSlider.value++;
    }
}
