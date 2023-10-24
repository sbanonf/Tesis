using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Trampoline : MonoBehaviour
{
    public float trampolineJumpPower;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Contacto", false); // Asegurarse de que el parámetro de animación "Contacto" esté en falso al inicio.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PC_Simple pc_simple = collision.gameObject.GetComponent<PC_Simple>();
            pc_simple.rb.velocity = Vector2.up * trampolineJumpPower;
            animator.SetBool("Contacto", true); // Establecer el parámetro de animación "Contacto" en verdadero cuando hay contacto.
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Contacto", true); // Mantener el parámetro de animación "Contacto" en verdadero mientras haya contacto.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("Contacto", false); // Establecer el parámetro de animación "Contacto" en falso cuando el jugador ya no está en contacto.
        }
    }
}
