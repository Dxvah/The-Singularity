using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
    float horizontalInput;
    float verticalInput;
    public Transform target;
    Rigidbody physics;
    

    private Vector3 targetDirection;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.freezeRotation = true;
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()                                                    //Movimiento del jugador
    {

        
        Vector3 movement = target.forward * verticalInput + target.right * horizontalInput;
        
        physics.AddForce(movement.normalized * speed, ForceMode.Force);    
    }
}