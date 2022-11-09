using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float cantidadPuntos;
    [SerializeField] private Score puntaje;
    public AudioClip coinsSFX;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            puntaje.SumarPuntos(cantidadPuntos);
            Destroy(gameObject);
            AudioManager.Instance.Reproducir(coinsSFX);
        }
    }
}
