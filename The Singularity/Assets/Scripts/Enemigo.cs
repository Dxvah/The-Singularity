using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : MonoBehaviour
{
    public GameObject player;
    
    public NavMeshAgent enemy;

    private void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player");            
    }
    void Update()
    {
       
        enemy.SetDestination(player.transform.position);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag ("Player"))
        {
            PauseGame();
        }
    }
    void PauseGame()
    {

        Time.timeScale = 0;
    }
}
