using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Button dialogueButton; // Asigna el botón desde el Inspector
    public Sprite Imagen;
    private bool playerInRange = false;

    private void Start()
    {
        // Desactiva el botón al inicio para que no se muestre.
        dialogueButton.onClick.AddListener(StartDialogue);
        dialogueButton.onClick.AddListener(SetearImagen);
        dialogueButton.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el tag coincida con el del jugador
        {
            playerInRange = true;
            // Activa el botón y muestra una indicación visual al jugador.
            dialogueButton.gameObject.SetActive(true);
            // Aquí puedes mostrar un mensaje en el Canvas, por ejemplo, "Presiona para hablar".
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            // Desactiva el botón y oculta la indicación visual.
            dialogueButton.gameObject.SetActive(false);
        }
    }

    // Este método se llamará cuando el botón se presione en el Canvas.
    public void StartDialogue()
    {
        if (playerInRange)
        {
            DialogueManager.instance.StartDialogue(dialogue);
            // Aquí puedes ocultar el botón u ocultar cualquier indicación visual.
        }
    }
    public void SetearImagen() {
        DialogueManager.instance.finalImage.sprite = Imagen;
    }
}
