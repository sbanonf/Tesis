﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Checkpoint : MonoBehaviour
{
    [SerializeField] int index;
    [SerializeField] Animator anim;
    public Transform checkpointPosition;
    [SerializeField] ParticleSystem particleSystem;

    public bool isSelected=false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (index == 0)
            SetAnimation(true);
    }

    public void SetAnimation(bool _isSelected)
    {
        isSelected = _isSelected;
        anim.SetBool("isSelected", _isSelected);
    }

    public void TurnOnParticle()
    {
        particleSystem.Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckpointManager.Instance.SetIndex(index);
        }
    }
}