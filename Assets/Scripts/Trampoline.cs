using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Trampoline : MonoBehaviour
{
    public float trampolineJumpPower;

    private void Awake()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            PC_SImple pc_simple = collision.gameObject.GetComponent<PC_SImple>();
            pc_simple.rb.velocity = Vector2.up * trampolineJumpPower;
        }
    }
}
