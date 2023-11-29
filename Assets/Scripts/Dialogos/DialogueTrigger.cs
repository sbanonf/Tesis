using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] DialogMember dialogMember;
    //public Dialogue dialogue;
    //public Button dialogueButton; // Asigna el bot?n desde el Inspector
    //public Sprite Imagen;
    //private bool playerInRange = false;

    private void Start()
    {
        // Desactiva el bot?n al inicio para que no se muestre.
        //dialogueButton.onClick.AddListener(StartDialogue);
        //dialogueButton.onClick.AddListener(SetearImagen);
        //dialogueButton.gameObject.SetActive(false);

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Aseg?rate de que el tag coincida con el del jugador
        {
            //playerInRange = true;
            //// Activa el bot?n y muestra una indicaci?n visual al jugador.
            //dialogueButton.gameObject.SetActive(true);
            //// Aqu? puedes mostrar un mensaje en el Canvas, por ejemplo, "Presiona para hablar".
            DialogSystem._instance.CallSpeech(dialogMember);
        }
    }

    //private void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.CompareTag("Player"))
    //    {
    //        playerInRange = false;
    //        // Desactiva el bot?n y oculta la indicaci?n visual.
    //        dialogueButton.gameObject.SetActive(false);
    //    }
    //}

    // Este m?todo se llamar? cuando el bot?n se presione en el Canvas.
    //public void StartDialogue()
    //{
    //    if (playerInRange)
    //    {
    //        DialogueManager.instance.StartDialogue(dialogue);
    //        // Aqu? puedes ocultar el bot?n u ocultar cualquier indicaci?n visual.
    //    }
    //}
    //public void SetearImagen() {
    //    DialogueManager.instance.finalImage.sprite = Imagen;
    //}
}
