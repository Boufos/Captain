using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip[] buttonSounds;
    
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        PlayClip(buttonSounds[Random.Range(0, buttonSounds.Length - 1)]);
    }

    private void PlayClip(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }
}
