using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard_Spike : MonoBehaviour
{
    //Si el personaje entra en contacto con este objeto
    //Bajale vida.
    private PC_SImple pc_simple;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerHealth>().DealDamage();
            pc_simple = collision.gameObject.GetComponent<PC_SImple>();
            pc_simple.rb.velocity = Vector2.up * pc_simple.jumpForce;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerHealth>().DealDamage();
            pc_simple = collision.gameObject.GetComponent<PC_SImple>();
            pc_simple.rb.velocity = Vector2.up * pc_simple.jumpForce;
        }
    }

}
