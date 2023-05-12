using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Jump Audio")]
    public AudioClip jumpClip;
    public AudioClip jump2Clip;

    [Header("Hit Audio")]
    public AudioClip hitClip;

    [Header("Trampoline Audio")]
    public AudioClip trampolineClip;

    [Header("Checkpoint Audio")]
    public AudioClip checkpointClip;

    [Header("Audio Sources")]
    public AudioSource playerSFXSource;
    public AudioSource trampolineSFXSource;
    public AudioSource checkpointSFXSource;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this.gameObject);
    }

    public void PlayJump()
    {
        if (!playerSFXSource.isPlaying)
        {
            playerSFXSource.clip = jumpClip;
            playerSFXSource.Play();
        }
    }

    public void PlayJump2()
    {
        if (!playerSFXSource.isPlaying)
        {
            playerSFXSource.clip = jump2Clip;
            playerSFXSource.Play();
        }
    }

    public void PlayHit()
    {
        if (!playerSFXSource.isPlaying)
        {
            playerSFXSource.clip = hitClip;
            playerSFXSource.Play();
        }
    }

    public void PlayTrampoline()
    {
        if (!trampolineSFXSource.isPlaying)
        {
            trampolineSFXSource.clip = trampolineClip;
            trampolineSFXSource.Play();
        }
    }

    public void PlayCheckpoint()
    {
        if (!checkpointSFXSource.isPlaying)
        {
            checkpointSFXSource.clip = checkpointClip;
            checkpointSFXSource.Play();
        }
    }
}
