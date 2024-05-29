using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    private Rigidbody2D fisicas;
    private Animator _animator;

    [Header("Movimiento")] 
    private float ejeX;
    [SerializeField] private float velocidadMovimiento;
    [SerializeField] private float suavizadoMovimiento;
    [SerializeField] private float salto;
    
    public AudioClip sonidoSalto;
    
    private Vector3 velocidad = Vector3.zero;
    private bool mirandoDerecha = true;
    private bool enSuelo;
    

    private void Start()
    {
        enSuelo = true;
        fisicas = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        ejeX = Input.GetAxis("Horizontal") * velocidadMovimiento;
        Salto();
    }

    private void FixedUpdate()
    {
        Mover(ejeX * Time.deltaTime); 
        Salto();
        _animator.SetFloat("derecha", Mathf.Abs(ejeX));
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Suelo")){
            enSuelo = true;
            _animator.SetBool("salto", false);
        }
    }

    
    private void Mover(float mover) {
        Vector3 velocidadObjetivo = new Vector2(mover, fisicas.velocity.y);
        fisicas.velocity = Vector3.SmoothDamp(fisicas.velocity, velocidadObjetivo, ref velocidad, suavizadoMovimiento);
        if (mover > 0 && !mirandoDerecha) {
            Girar();
        }else if (mover <0 && mirandoDerecha) {
            Girar();
        }
    }

    private void Girar() {
        mirandoDerecha = !mirandoDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        /*
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
        */
    }
    
    private void Salto() {
        if (Input.GetButtonDown("Jump") && enSuelo){
            AudioManager.Instance.Reproducir(sonidoSalto);
            fisicas.AddForce(new Vector2(0, salto), ForceMode2D.Impulse);
            enSuelo = false;
            _animator.SetBool("salto", true);
        }
    }

}
