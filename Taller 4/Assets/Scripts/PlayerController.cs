using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float velMovimiento = 3;

    [SerializeField] private float turnSmoothTime = 0.1f;

    private float turnVelocity;
    private CharacterController controller;

    public Transform cam;  

    void Start() 
    {
      controller = GetComponent<CharacterController>();  
    }
    void Update()
    {
        Movimiento();
    }

    private void Movimiento()
    {    
        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(hor, 0f, ver).normalized;

        if (direction.magnitude > 0)
        {
            // es el objetivo de la rotación
            float targetAngle = Mathf.Atan2(direction.x,direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            // hace que las rotaciones se vean más suaves
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoothTime);

            // cambia la dirección del personaje segun la donde apunte la camara
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // cambia el angulo de rotación del objeto
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // cambia la dirección en la que se mueve el personaje
            controller.Move(moveDir.normalized * velMovimiento * Time.deltaTime);
        }
    }
}
