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

   

    public void SetBeingWatched(bool isWatched)
    {
        isBeingWatched = isWatched;
        //enemyAnim.enabled = isBeingWatched;
        if (isWatched)
        {
            enemyAnim.enabled = false;
            enemy.isStopped = true;
        }
        else
        {
            enemyAnim.enabled = true;
            enemy.isStopped = false;

        }
        //Debug.Log("El enemigo está siendo observado: " + isWatched);
    }
}



