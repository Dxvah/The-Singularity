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
    }


    void Update()
    {

    }

    private void FixedUpdate()                                                    //Movimiento del jugador
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);

        
       

        
        target.position = transform.position;
    }
}