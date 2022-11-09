using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        { 
            Instance = this;
        }
        else
        {
            Debug.Log("Cuidado! Hay mas de un AudioManager en escena");
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void Reproducir(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
