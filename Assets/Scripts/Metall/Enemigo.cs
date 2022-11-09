using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida;
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;

    public void Daño(float daño) {
        vida -= daño;
        if (vida <= 0) {
            Muerte();
        }
    }

    private void Muerte() {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.collider.CompareTag("Player")) {
            tiempoSiguienteDaño -= Time.deltaTime;
            if (tiempoSiguienteDaño <= 0) {
                col.collider.GetComponent<Combate>().Daño(1);
                tiempoSiguienteDaño = tiempoEntreDaño;
            }
        }
    }
}
