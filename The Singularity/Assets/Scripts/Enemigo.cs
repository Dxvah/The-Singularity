using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent enemy;
    public Collider enemyCol;
    public Animator enemyAnim;
    private bool isBeingWatched = false;
    public AudioSource audioDeath;
    public Canvas canvaDeath;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemyCol = GetComponent<Collider>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (!isBeingWatched)
        {
            enemy.SetDestination(player.transform.position);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        audioDeath.Play();
        
        Time.timeScale = 0;
    }

    void RestartGame()
    {
        canvaDeath.enabled = true;
        Time.timeScale = 1;
    }

    public void SetBeingWatched(bool isWatched)
    {
        isBeingWatched = isWatched;
        if (isWatched)
        {
            enemyAnim.enabled = false;
        }
        else
        {
            enemyAnim.enabled = true;
        }
        //Debug.Log("El enemigo est� siendo observado: " + isWatched);
    }
}



