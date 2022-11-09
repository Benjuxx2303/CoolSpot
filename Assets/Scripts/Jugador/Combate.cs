using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float maximoVida;
    [SerializeField] private BarraDeVida barraDeVida;

    private void Start() {
        vida = maximoVida;
        barraDeVida.InicializarBarraDeVida(vida);
    }

    public void Daño(float daño) {
        vida -= daño;
        barraDeVida.CambiarVidaActual(vida);
        if (vida <= 0) {
            Destroy(gameObject);
        }
    }

    public void Curar(int curacion) {
        if ((vida + curacion) > maximoVida) {
            vida = maximoVida;
            barraDeVida.CambiarVidaActual(vida);
        }else {
            vida += curacion;
            barraDeVida.CambiarVidaActual(vida);
        }
    }
    
}
