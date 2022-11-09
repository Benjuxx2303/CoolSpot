using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float puntos;
    private TextMeshProUGUI texto;

    private void Start()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        //SumarPuntos(puntos);
        
    }

    public void SumarPuntos(float puntosEntrada)
    {
        puntos = puntos + puntosEntrada;
        texto.text = puntos.ToString("0");
    }
}
