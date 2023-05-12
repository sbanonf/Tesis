using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SO_SetearSeñas : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public Image image;
    public ScriptableSeñas seña;

    private void Awake()
    {
        image.color = Color.black;
    }
    private void Update()
    {
        if (seña.Activo) {
            Text.text = seña.Descripcion;
            image.sprite = seña.img;
            image.color = Color.white;
        }
    }
}


