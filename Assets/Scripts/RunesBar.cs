using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunesBar : MonoBehaviour
{
    private Slider mSlider;
    public GameObject gameObject;
    private void Start()
    {
        mSlider = GetComponent<Slider>();
    }

    private void Update()
    {
        mSlider.value = RunesManager.Instance.cantidad;
        if (RunesManager.Instance.cantidad == mSlider.maxValue) {
            gameObject.SetActive(true);        
        }
    }
}
