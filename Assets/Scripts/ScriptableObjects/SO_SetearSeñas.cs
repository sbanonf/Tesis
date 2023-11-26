using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SO_SetearSeñas : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Image image;
    public ScriptableSenias senia;

    private void Awake()
    {
        image.color = Color.black;
    }
    private void Update()
    {
        if (senia.Activo) {
            Text.text = senia.Descripcion;
            image.sprite = senia.img;
            image.color = Color.white;
        }
    }
}


