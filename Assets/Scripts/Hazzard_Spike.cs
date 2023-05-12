using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazzard_Spike : MonoBehaviour
{
    //Si el personaje entra en contacto con este objeto
    //Bajale vida.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // collision.gameObject.GetComponent<PlayerController>().DamageAnimation();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // collision.gameObject.GetComponent<PlayerController>().DamageAnimation();
        }
    }
}
