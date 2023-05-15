using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunesBar : MonoBehaviour
{
    private Slider mSlider;
    public GameObject gameObject;
    public int cont = 0;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
        cont = 0;
    }

    private void Update()
    {
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
