using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    [SerializeField] private Transform disparo;
    [SerializeField] private GameObject bala;
    public AudioClip sonidoDisparo;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Disparar();
            
        }
    }

    private void Disparar()
    {
        Instantiate(bala, disparo.position, disparo.rotation);
        AudioManager.Instance.Reproducir(sonidoDisparo);
    }
}
