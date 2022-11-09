using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVida : MonoBehaviour

{
    public AudioClip sonidoVida;
    private void OnTriggerEnter2D(Collider2D col) {
        if (col.CompareTag("Player")) {
            col.GetComponent<Combate>().Curar(1);
            AudioManager.Instance.Reproducir(sonidoVida);
            Destroy(gameObject);
        }
    }
}
