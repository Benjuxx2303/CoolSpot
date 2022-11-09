using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoJugador : MonoBehaviour
{
    public AudioManager audioManager;
    [SerializeField] private Transform CtrlDisparo;
    [SerializeField] private GameObject bala;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Disparar();

        }
    }

    void Disparar()
    {
        Instantiate(bala, CtrlDisparo.position, CtrlDisparo.rotation);
    }
}
