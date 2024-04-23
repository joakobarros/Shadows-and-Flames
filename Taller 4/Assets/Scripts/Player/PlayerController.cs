using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float velMov = 3;
    [SerializeField] private float turnSmoothTime = 0.1f;
    [SerializeField] private float jumpForce = 5f; 
    [SerializeField] private bool jumping;

    private Rigidbody rb;
    private float turnVelocity;
    private Vector3 direction;
    public Transform orientation;


    void Start() 
    {
        rb = GetComponent<Rigidbody>();  
    }
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {    
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        direction = new Vector3(hor, 0f, ver);

        Vector3 velocity = Vector3.zero;

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
        
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if (Input.GetButtonDown("Jump") && jumping)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            jumping = false; 
        }
    }
    private void OnCollisionEnter(Collision other) 
    {
        jumping = true;    
    }
}
