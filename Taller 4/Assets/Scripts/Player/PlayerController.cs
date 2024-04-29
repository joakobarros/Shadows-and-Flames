using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float velMov = 3;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] public bool jumping;
    [SerializeField] private float fallTime;
    [SerializeField] private float fallDamage;
    [SerializeField] private float hitImpulse;
    [SerializeField] public bool attacking = true;

    public PlayerCombat playerCombat;
    private Rigidbody rb;
    private Animator anim;
    private float turnVelocity;
    private Vector3 direction;
    public Transform orientation;
    private GameObject me;
    private bool avanzaSolo;
    
    
    void Start() 
    {
        rb = GetComponent<Rigidbody>();  
        me = this.gameObject;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        Movimiento();

        if (!jumping)
        {
            fallTime += Time.deltaTime;
        }
    }

    private void Movimiento()
    {    
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Hor", hor);
        anim.SetFloat("Ver", ver);

        direction = new Vector3(hor, 0f, ver);

        Vector3 velocity = Vector3.zero;

        if (!attacking)
        {
            if (hor != 0 || ver != 0)
            {
                // es el objetivo de la rotación
                float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg;

                // cambia la dirección del personaje segun la donde apunte la camara
                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * orientation.forward;

                float movedirAngle = Mathf.Atan2(moveDir.x, moveDir.z) * Mathf.Rad2Deg;
                
                // hace que las rotaciones se vean más suaves
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, movedirAngle, ref turnVelocity, turnSmoothTime);

                // cambia el angulo de rotación del objeto
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                // cambia la dirección en la que se mueve el personaje
                velocity = moveDir.normalized * velMov;
            }
        }
        
        
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if (jumping)
        {
            //!attacking
            if (Input.GetButtonDown("Jump"))
            {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                jumping = false; 
                anim.SetBool("Salto", !jumping);
            }
            anim.SetBool("TocoSuelo", jumping);
        }
        else
        {
            Falling();
        }

        if (avanzaSolo)
        {
            rb.velocity = transform.forward * hitImpulse;
        }
        
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if (fallTime > fallDamage)
            {
                me.GetComponent<PlayerLife>().OnHit(5 * fallDamage);
            }

            fallTime = 0;
        } 
    }

    private void Falling()
    {
        anim.SetBool("TocoSuelo", false);
        anim.SetBool("Salto", false);
    }

    public void StopAttacking ()
    {
        attacking = false;
    }

    public void AttackImpulse()
    {
        avanzaSolo = true;
    }

    public void StopImpulse()
    {
        avanzaSolo = false;
    }
}
