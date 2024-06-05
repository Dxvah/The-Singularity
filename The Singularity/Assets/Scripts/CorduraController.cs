using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CorduraController : MonoBehaviour
{
    public Slider corduraSlider;
    public float maxCordura = 100f;
    public float minTime = 120f;
    public float corduraDecayRate = 1f;
    public GameObject enemyPrefab;
    public Transform spawnLocation;
    public AudioSource backgroundMusic;
    public AudioClip[] enemySounds;

    private float currentCordura;
    private float timeInScene;
    private bool corduraDecreasing = false;

    private bool yaExiste = false;

    void Start()
    {
        currentCordura = maxCordura;
        timeInScene = 0f;
        corduraSlider.maxValue = maxCordura;
        corduraSlider.value = currentCordura;
    }

    void Update()
    {
        timeInScene += Time.deltaTime;

        if (!corduraDecreasing && timeInScene >= minTime + Random.Range(0f, 60f))
        {
            corduraDecreasing = true;
        }

        if (corduraDecreasing)
        {
            currentCordura -= corduraDecayRate * Time.deltaTime;
            corduraSlider.value = currentCordura;

            if (currentCordura <= 0 && !yaExiste)
            {
                EnemySpawning();
            }
        }
    }

    void EnemySpawning()
    {
        backgroundMusic.Stop();

        GameObject enemy = Instantiate(enemyPrefab, spawnLocation.position, spawnLocation.rotation);
        AudioSource enemyAudioSource = enemy.AddComponent<AudioSource>();
        enemyAudioSource.clip = enemySounds[Random.Range(0, enemySounds.Length)];
        enemyAudioSource.Play();

        corduraDecreasing = false;
        yaExiste = true;
    }
}

