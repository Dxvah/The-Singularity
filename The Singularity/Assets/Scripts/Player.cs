using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float velocidad = 10, velRotacion = 5;
    Rigidbody fisicas;
    public Transform pTransform;
    void Start()
    {
        fisicas = GetComponent<Rigidbody>();
    }


    void Update()
    {

    }
    private void FixedUpdate()                                                    //Movimiento del jugador
    {
        if (Input.GetKey(KeyCode.W))
        {
            fisicas.velocity = transform.forward * velocidad;

        }
        if (Input.GetKey(KeyCode.S))
        {
            fisicas.velocity = -transform.forward * velocidad;

        }
        if (Input.GetKey(KeyCode.A))
        {
            pTransform.Rotate(0, -velRotacion, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            pTransform.Rotate(0, velRotacion,  0);
        }
    }
}