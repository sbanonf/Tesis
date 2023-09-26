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
    public GameObject pelea;
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
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escenaActual);
        }
        else if (mSlider.value >= mSlider.maxValue) {
            SceneManager.LoadScene("Nivel 2");
        }
    }
    public void Disminuir() {
        AudioManager.instance.Play("error");
        mSlider.value--;
        RectTransform rect = pelea.GetComponent<RectTransform>();
        if (rect.anchoredPosition.x > -401.8)
        {
            rect.anchoredPosition = new Vector2((rect.anchoredPosition.x - 66.2f), rect.anchoredPosition.y);
        }
    }
    public void Aumentar() {
        AudioManager.instance.Play("correct");
        mSlider.value++;
        RectTransform rect = pelea.GetComponent<RectTransform>();
        if (rect.anchoredPosition.x < 331) {
            rect.anchoredPosition = new Vector2((rect.anchoredPosition.x + 66.2f), rect.anchoredPosition.y);
        }
    }
}
