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
        // Aquí puedes lanzar el diálogo del NPC
        DialogueTrigger dialogueTrigger = GetComponent<DialogueTrigger>();
        if (dialogueTrigger != null)
        {
          //  dialogueTrigger.();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC")) // Asegúrate de que el tag coincida con tu NPC
        {
            isInteracting = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC")) // Asegúrate de que el tag coincida con tu NPC
        {
            isInteracting = false;
        }
    }
}
