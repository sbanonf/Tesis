using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunesBar : MonoBehaviour
{
    private Slider mSlider;
    public TextMeshProUGUI text;
    public GameObject gameObject;
    public int cont = 0;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        cont = 0;
    }

    private void Update()
    {
        text.text = mSlider.value.ToString() + "  /  " + mSlider.maxValue.ToString();
        mSlider.value = RunesManager.Instance.cantidad;
        if (RunesManager.Instance.cantidad == mSlider.maxValue) {
            if (cont == 0) {
                AudioManager.instance.Play("Fin");
                cont++;
            }
            gameObject.SetActive(true);        
        }
    }
}
