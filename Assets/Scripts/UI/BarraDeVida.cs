using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    public AudioClip sonidoDano;

    private void Start() {
        
    }

    public void CambiarVidaMaxima(float vidaMaxima) {
        slider.maxValue = vidaMaxima;
    }

    public void CambiarVidaActual(float cantidadVida) {
        slider.value = cantidadVida;
        AudioManager.Instance.Reproducir(sonidoDano);
    }

    public void InicializarBarraDeVida(float cantidadVida) {
        slider = GetComponent<Slider>();
        CambiarVidaActual(cantidadVida);
        CambiarVidaMaxima(cantidadVida);
    }
}
