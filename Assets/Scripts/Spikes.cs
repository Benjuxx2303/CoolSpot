using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float tiempoEntreDaño;
    private float tiempoSiguienteDaño;
    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            tiempoSiguienteDaño -= Time.deltaTime;
            if (tiempoSiguienteDaño <= 0)
            {
                other.GetComponent<Combate>().Daño(2);
                tiempoSiguienteDaño = tiempoEntreDaño;
            }
        }
    }
}
