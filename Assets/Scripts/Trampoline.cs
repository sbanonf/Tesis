using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Trampoline : MonoBehaviour
{
    public Animator animator;
    public float trampolineJumpPower;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //collision.gameObject.GetComponent<PlayerController>().TrampolineJump(trampolineJumpPower);
        }
    }
}
