using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float mouseSensitivity = 2f;
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

    }

    private void FixedUpdate()                                                    //Movimiento del jugador
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector3 movement = target.forward * verticalInput + target.right * horizontalInput;
        physics.AddForce(movement.normalized * speed, ForceMode.Force);    
    }
}