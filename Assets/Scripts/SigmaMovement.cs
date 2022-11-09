using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigmaMovement : MonoBehaviour
{
    public float Velocidad ;
    public float Jump;
    public int maximSaltos;
    private float Horizontal;
    public float vida = 100;
    
    public LayerMask capaSuelo;
    public AudioManager audioManager;
    public AudioClip sonido_isRunning;
    public AudioClip sonido_isAtacck;
    public AudioClip sonido_isJump;
    
    private Animator Animator;
    private int saltosRes;
    private bool mirandoDerecha = true;
    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D boxCollider;
    
    
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        Animator = GetComponent<Animator>();
        saltosRes = maximSaltos;
    }

    void Update()
    {
        Moverse();
        Atacar();
        Bloquear();
        Desplazar();
        Saltar();
    }

    public void Daño(float daño)
    {
        vida -= daño;
        if (vida <= 0)
        {
            Muerte();
        }
    }

    private void Muerte()
    {
        Animator.SetBool("isDeath", true);
        Destroy(gameObject);
    }
    bool enPiso()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, 
            new Vector2(boxCollider.bounds.size.x,
            boxCollider.bounds.size.y), 
            0f,Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }
    void Moverse()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            float inputMoverse = Input.GetAxis("Horizontal");
            Rigidbody2D.velocity = new Vector2(inputMoverse * Velocidad, Rigidbody2D.velocity.y);
            Orientacion(inputMoverse);
        }
    }

    void Orientacion(float inputMoverse)
    {
        // Condición
        if ( (mirandoDerecha == true && inputMoverse < 0) || (mirandoDerecha == false && inputMoverse > 0) )
        {
            // Negacion de valor.
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
    void Saltar()
    {
        if (enPiso())
        {
            saltosRes = maximSaltos;
        }
        if (Input.GetKeyDown(KeyCode.P) && saltosRes > 0)
        {
            saltosRes--;
            Rigidbody2D.AddForce(Vector2.up * Jump, ForceMode2D.Impulse);
            Animator.SetBool("isJump", true);
            audioManager.Reproducir(sonido_isJump);
        }
    }
    
    void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Animator.SetBool("isAtacck", true);
            audioManager.Reproducir(sonido_isAtacck);
        } 
    }
    
    
    void Bloquear()
    { 
        if (Input.GetKeyDown(KeyCode.U))
        {
            Animator.SetBool("isBlock", true);
        }
    }

    void Desplazar()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            Animator.SetBool("isRunning", true);
            audioManager.Reproducir(sonido_isRunning);
        }
    }

}
