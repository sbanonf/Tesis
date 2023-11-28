using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeTime : MonoBehaviour
{
    public static LifeTime _instance;
    public Image[] child;
    [SerializeField] CanvasGroup canvasGroup;


    private void Awake()
    {
        _instance = this;
        child = GetComponentsInChildren<Image>(true);
        canvasGroup.CanvasGroupFade(0);
        canvasGroup.CanvasGroupInteractable(false);
    }

    public void Setear(ScriptableSenias so) {
        canvasGroup.CanvasGroupFade(1);
        child[1].sprite = so.img;
        Invoke("OcultarPopup", 3f);
    }
    public void OcultarPopup() {
        //this.gameObject.SetActive(false);
        canvasGroup.CanvasGroupFade(0);
    }

}
