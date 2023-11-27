using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PopUp : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] GameObject popup_GO;
    [SerializeField] CanvasGroup canvasGroup;

    [Header("Variables")]
    [SerializeField] string text;
    [SerializeField] bool willChangeScene;
    [SerializeField] string sceneName;

    [SerializeField] AnimationCurve animCurve;
    protected float scaledTime;
    Coroutine currentCoroutine = null;

    private void Start()
    {
        textMesh.text = text;
        scaledTime = Time.fixedDeltaTime * DialogUtils.timeScaler;
        Initialize();
    }

    public void Initialize()
    {
        canvasGroup.CanvasGroupFade(0);
        canvasGroup.CanvasGroupInteractable(false);
        //popup_GO.SetActive(false);
    }


    public void TurnOn()
    {
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(Initialize(true));
    }

    public void TurnOff()
    {
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(Initialize(false));
    }

    IEnumerator Initialize(bool isFading)
    {
        if (isFading)
        {
            //popup_GO.SetActive(true);
            yield return null;

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
            for (float i = 0; i < DialogUtils.maxTime; i += scaledTime)
            {
                float tempValue = animCurve.Evaluate(1 - (i / DialogUtils.maxTime));
                canvasGroup.CanvasGroupFade(tempValue);
                yield return null;
            }
            canvasGroup.CanvasGroupInteractable(false);
            //popup_GO.SetActive(false);

            if (willChangeScene)
                SceneManager.LoadScene(sceneName);
        }

        // If close, then empty and reset values
        currentCoroutine = null;
    }

    public void Reset()
    {
        canvasGroup.CanvasGroupFade(0);
        canvasGroup.CanvasGroupInteractable(false);
    }
}
