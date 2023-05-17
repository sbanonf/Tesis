using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour
{
    public Image[] child;
    private void Awake()
    {
        child = GetComponentsInChildren<Image>(true);
    }

    public void Setear(ScriptableSeñas so) {
        child[1].sprite = so.img;
        Invoke("OcultarPopup", 3f);
    }
    public void OcultarPopup() {
        this.gameObject.SetActive(false);
    }

}
