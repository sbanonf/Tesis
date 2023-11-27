using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class CharDialog
{
    [SerializeField] int charDialogId;
    public int CharDialogId { get { return charDialogId; } }

    [SerializeField] List<string> dialogChar = new List<string>();
    public List<string> DialogChar { get { return dialogChar; } }

    [SerializeField] List<string> dialogNPC = new List<string>();
    public List<string> DialogNPC { get { return dialogNPC; } }

}

public class DialogSystem : MonoBehaviour
{
    public static DialogSystem _instance;

    [Header("UI Components")]
    [SerializeField] private Image border;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private GameObject waitingImage;
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Main Character")]
    [SerializeField] private Color mainCharColor;
    [SerializeField] private CharacterUITemplate mainChar;

    [Header("NPC Character")]
    [SerializeField] private Color npcColor;
    [SerializeField] private CharacterUITemplate npcChar;

    [Header("Dialog Member")]
    [SerializeField] private DialogMember tempSpeech;

    [SerializeField] AnimationCurve animCurve;
    private float scaledTime;

    public bool canInteract = true;
    [SerializeField] private int characterIndex = 0;

    Coroutine currentCoroutine = null;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        scaledTime = Time.fixedDeltaTime * DialogUtils.timeScaler;

        Initialize();

        canvasGroup.CanvasGroupFade(0);
        canvasGroup.CanvasGroupInteractable(false);
    }

    private void Initialize()
    {
        waitingImage.gameObject.SetActive(false);
        SetText("");
        mainChar.Initialize();
        npcChar.Initialize();
        characterIndex = 0;
    }

    public void CallSpeech(DialogMember _)
    {
        tempSpeech = _;
        if (currentCoroutine == null)
            currentCoroutine = StartCoroutine(AnimateDialog());
    }

    IEnumerator AnimateDialog()
    {
        for(float i = 0; i < DialogUtils.maxTime; i += scaledTime)
        {
            float tempValue = animCurve.Evaluate(i / DialogUtils.maxTime);
            canvasGroup.CanvasGroupFade(tempValue);
            yield return null;
        }
        canvasGroup.CanvasGroupInteractable(true);

        canInteract = false;

        yield return StartCoroutine(TypeWriting());

        canInteract = true;
        currentCoroutine = null;
    }

    IEnumerator TypeWriting()
    {
        string tempText = "";

        //Fade In SpeechBubble and SpeechText
        dialogText.text = tempText;

        // Typewrite effect Reading one of the multiple list of phrases
        int wordCounter = 0;
        List<string> tempPhrase = new List<string>();

        tempPhrase = tempSpeech.DialogCharacters[0].speech;
        yield return SelectCharacterDialog(tempSpeech.DialogCharacters[characterIndex]);

        while (true)
            //If wordcounter is less than the tempPhrase size, then run
            if (wordCounter < tempPhrase.Count)
            {
                for (int i = 0; i < tempPhrase[wordCounter].Length; i++)
                {
                    tempText += tempPhrase[wordCounter][i];
                    dialogText.text = "" + tempText;
                    yield return new WaitForSeconds(DialogUtils.waitTime);
                }

                while (DialogCondition())
                {
                    if (waitingImage.gameObject != null)
                        waitingImage.gameObject.SetActive(true);
                    yield return null;
                }

                waitingImage.gameObject.SetActive(false);

                wordCounter++;
                tempText = "";
            }
            else
            {
                yield return new WaitForSeconds(.5f);
                if (characterIndex < tempSpeech.DialogCharacters.Count - 1)
                {
                    characterIndex++;

                    dialogText.text = "";

                    tempPhrase = tempSpeech.DialogCharacters[characterIndex].speech;
                    yield return SelectCharacterDialog(tempSpeech.DialogCharacters[characterIndex]);

                    wordCounter = 0;
                }
                else
                {
                    break;
                }
            }

        Initialize();

        for (float i = DialogUtils.maxTime; i >= 0; i -= scaledTime)
        {
            float tempValue = animCurve.Evaluate(i / DialogUtils.maxTime);
            canvasGroup.CanvasGroupFade(tempValue);
            yield return null;
        }
        canvasGroup.CanvasGroupInteractable(false);
    }

    IEnumerator SelectCharacterDialog(CharacterSpeech _)
    {
        for (float i = 0; i < DialogUtils.maxTime; i += scaledTime)
        {
            float tempValue = animCurve.Evaluate(i / DialogUtils.maxTime);

            if (_.dialogCharacter == DialogCharactersEnum.MainCharacter)
            {
                mainChar.CanvasGroupFade(tempValue);
                if (npcChar.GetCanvasGroupFade() > 0)
                    npcChar.CanvasGroupFade(1 - tempValue);
            }
            else
            {
                npcChar.CanvasGroupFade(tempValue);
                if (mainChar.GetCanvasGroupFade() > 0)
                    mainChar.CanvasGroupFade(1 - tempValue);
            }

            SetDialogVisualsLerp(_.dialogCharacter, tempValue);

            yield return null;

            if (_.dialogCharacter == DialogCharactersEnum.MainCharacter)
            {
                if (i <= 0)
                    npcChar.CanvasGroupInteractable(false);

                if (i >= DialogUtils.maxTime)
                    mainChar.CanvasGroupInteractable(true);
            }
            else
            {
                if (i <= 0)
                    mainChar.CanvasGroupInteractable(false);

                if (i >= DialogUtils.maxTime)
                    npcChar.CanvasGroupInteractable(true);
            }
        }
    }

    #region Base Conditional for input dialog

    private bool DialogCondition()
    {
        return !Input.GetKeyDown(KeyCode.Space) && !Input.GetMouseButton(0);
    }

    #endregion

    #region Base functions

    void SetDialogVisualsLerp(DialogCharactersEnum _, float lerpValue)
    {
        Color initialColor= _ == DialogCharactersEnum.MainCharacter ? npcColor : mainCharColor;
        Color endColor = _ == DialogCharactersEnum.MainCharacter ? mainCharColor : npcColor;

        Color lerpVal = Color.Lerp(initialColor, endColor, lerpValue);
        border.color = lerpVal;
        dialogText.color = lerpVal;
    }

    void SetText(string text)
    {
        dialogText.text = text;
    }

    #endregion

}
