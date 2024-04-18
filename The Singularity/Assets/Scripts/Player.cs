using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 100f;
    public float mouseSensitivity = 2f;
    public float horizontalInput;
    public float verticalInput;
    public Transform target;
    Rigidbody physics;
    PlayerInput playerInput;
    

    private Vector3 targetDirection;
    void Start()
    {
        physics = GetComponent<Rigidbody>();
        physics.freezeRotation = true;
        playerInput = GetComponent<PlayerInput>();
    }


    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()                                                    //Movimiento del jugador
    {

        Debug.Log(target.forward);
        Vector3 movement = target.forward.normalized * verticalInput + target.right.normalized * horizontalInput;
        
        physics.AddForce(movement.normalized * speed, ForceMode.Force);

        transform.Rotate(new Vector3(0,/*Distancia en angulos entre la rotación de la camara y la mia*/,0));
    }
}