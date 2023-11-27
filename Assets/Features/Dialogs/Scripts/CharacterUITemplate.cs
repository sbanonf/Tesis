using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUITemplate : MonoBehaviour
{
    [SerializeField] protected CanvasGroup canvasGroup;

    public virtual void Initialize()
    {
        canvasGroup.CanvasGroupFade(0);
        canvasGroup.CanvasGroupInteractable(false);
    }

    public void CanvasGroupFade(float fadeValue)
    {
        canvasGroup.CanvasGroupFade(fadeValue);
    }

    public void CanvasGroupInteractable(bool isInteractable)
    {
        canvasGroup.CanvasGroupInteractable(isInteractable);
    }

    public float GetCanvasGroupFade()
    {
        return canvasGroup.GetCanvasGroupFade();
    }
}
