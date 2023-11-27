using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject genealogicUI_GO;
    [SerializeField] CanvasGroup canvasGroup;
    Coroutine currentCoroutine = null;

    [SerializeField] AnimationCurve animCurve;
    private float scaledTime;

    [Header("Info")]
    [SerializeField] DragNDropManager dragNDropManager;

    private void Start()
    {
        scaledTime = Time.fixedDeltaTime * DialogUtils.timeScaler;
        Initialize();
    }

    public void Initialize()
    {
        canvasGroup.CanvasGroupFade(0);
        canvasGroup.CanvasGroupInteractable(false);
        genealogicUI_GO.SetActive(false);
    }

    public void Select()
    {
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(Initialize(true));
    }

    public void Close()
    {
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(Initialize(false));
    }

    IEnumerator Initialize(bool isFading)
    {
        if (isFading)
        {
            ValidateManager._instance.ResetLevelPopUp();
            genealogicUI_GO.SetActive(true);
            yield return null;
            // Initialize images and text, Initialize signs
            dragNDropManager.Initialize();

            // Here

            // Run Animation for canvas
            for (float i = 0; i < DialogUtils.maxTime; i += scaledTime)
            {
                float tempValue = animCurve.Evaluate(i / DialogUtils.maxTime);
                canvasGroup.CanvasGroupFade(tempValue);
                yield return null;
            }
            canvasGroup.CanvasGroupInteractable(true);
        }
        else
        {
            ValidateManager._instance.CleanValidateManager();
            for (float i = 0; i < DialogUtils.maxTime; i += scaledTime)
            {
                float tempValue = animCurve.Evaluate(1 - (i / DialogUtils.maxTime));
                canvasGroup.CanvasGroupFade(tempValue);
                yield return null;
            }
            canvasGroup.CanvasGroupInteractable(false);
            dragNDropManager.Reset();
            genealogicUI_GO.SetActive(false);
        }

        // If close, then empty and reset values

        currentCoroutine = null;
    }
}
