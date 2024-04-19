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

        
        Vector3 camaraFwd = target.forward;
        Vector3 camaraRight = target.right;
        camaraFwd.y = 0f;
        camaraRight.y = 0f;
        Vector3 movement = camaraFwd.normalized * verticalInput + camaraRight.normalized * horizontalInput;
        
        physics.AddForce(movement.normalized * speed, ForceMode.Force);

        
    }
}