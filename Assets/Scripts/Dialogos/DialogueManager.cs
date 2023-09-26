using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance; // Singleton instance
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBox;
    public Button tstart;
    public Button siguiente;
    private Queue<string> sentences;
    public Image finalImage;
    public Image Box;

    private void Awake()
    {
        // Ensure only one instance of DialogueManager exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Don't destroy this object when loading new scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        sentences = new Queue<string>();
        dialogueBox.SetActive(false); // Oculta el cuadro de diálogo al inicio
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        dialogueBox.SetActive(true);
        Box.gameObject.SetActive(false);
        tstart.gameObject.SetActive(false);
        siguiente.gameObject.SetActive(true);
        finalImage.gameObject.SetActive(false);// Activa el cuadro de diálogo

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    public void ShowFinalImage()
    {
        if (finalImage != null)
        {
            Box.gameObject.SetActive(true);
            finalImage.gameObject.SetActive(true);
        }
    }
    void EndDialogue()
    {
        siguiente.gameObject.SetActive(false);
        ShowFinalImage();
        Invoke("HideDialogue", 2f); // Oculta el cuadro de diálogo al final del diálogo
    }
    void HideDialogue()
    {
        dialogueBox.SetActive(false); // Oculta el cuadro de diálogo después de 5 segundos
    }
}
