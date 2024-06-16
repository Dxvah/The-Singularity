using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 100f;
    public float mouseSensitivity = 2f;
    public float horizontalInput;
    public float verticalInput;
    public Transform target;
    Rigidbody physics;
    PlayerInput playerInput;

    public AudioSource steps;
    private Vector3 targetDirection;
    private bool isMoving = false;
    public Canvas canvaDeath;
    public AudioSource audioDeath;

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

        bool wasMoving = isMoving;
        isMoving = (horizontalInput != 0 || verticalInput != 0);

        if (isMoving && !wasMoving)
        {
            steps.Play();
        }
        else if (!isMoving && wasMoving)
        {
            steps.Pause();
        }
    }

    private void FixedUpdate()
    {
        Vector3 camaraFwd = target.forward;
        Vector3 camaraRight = target.right;
        camaraFwd.y = 0f;
        camaraRight.y = 0f;
        Vector3 movement = camaraFwd.normalized * verticalInput + camaraRight.normalized * horizontalInput;
        physics.AddForce(movement.normalized * speed, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            PauseGame();
        }
        if (collision.gameObject.CompareTag("boca"))
        {
            Debug.Log("tan comio");
            SceneManager.LoadScene("3"); 
        }
    }

    void PauseGame()
    {
        audioDeath.Play();
        canvaDeath.enabled = true;
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        canvaDeath.enabled = false;
        Time.timeScale = 1;
    }
}
