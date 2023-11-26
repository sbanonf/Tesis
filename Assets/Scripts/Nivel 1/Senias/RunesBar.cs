using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunesBar : MonoBehaviour
{
    private Slider mSlider;
    public TextMeshProUGUI text;
    public TextMeshProUGUI text2;
    public GameObject gameObject;
    public int cont = 0;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
        cont = 0;
    }

    private void Update()
    {
        text.text = mSlider.value.ToString();
        text2.text = mSlider.maxValue.ToString();
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
