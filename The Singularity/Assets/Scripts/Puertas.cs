using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puertas : MonoBehaviour
{
    private bool playerInRange = false;
    private RayCastCamera raycastCamera; 

    void Start()
    {
        raycastCamera = GetComponentInChildren<RayCastCamera>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerInRange = true;
            raycastCamera = collision.collider.GetComponent<RayCastCamera>();
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) 
        {
            playerInRange = false;
            raycastCamera = null;
        }
    }

    void Update()
    {
        if (playerInRange && raycastCamera != null && raycastCamera.hasCogidoElObjeto) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("nos vamo");
                SceneManager.LoadScene("2");
            }
        }
    }
}

