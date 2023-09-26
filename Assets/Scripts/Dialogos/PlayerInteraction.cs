using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private bool isInteracting = false;

    void Update()
    {
        if (isInteracting && Input.GetKeyDown(KeyCode.E)) // Puedes cambiar "E" por la tecla que prefieras para interactuar
        {
            Interact();
        }
    }

    void Interact()
    {
        // Aqu� puedes lanzar el di�logo del NPC
        DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
        if (dialogueTrigger != null)
        {
          //  dialogueTrigger.();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC")) // Aseg�rate de que el tag coincida con tu NPC
        {
            isInteracting = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC")) // Aseg�rate de que el tag coincida con tu NPC
        {
            isInteracting = false;
        }
    }
}
