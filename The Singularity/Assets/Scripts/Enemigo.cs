using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    public NavMeshAgent enemy;
    public Collider enemyCol;
    public Animator enemyAnim;
    private bool isBeingWatched = false;

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
        Time.timeScale = 0;
    }

    void RestartGame()
    {
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
        Debug.Log("El enemigo está siendo observado: " + isWatched);
    }
}



