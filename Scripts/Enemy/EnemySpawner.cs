using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    [Header("Spawn Time")]
    private float spawnTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer();
    }

    public void SpawnTimer()
    {
        if (spawnTime >= 0)
        {
            spawnTime -= Time.deltaTime;
        }
        else
        {
            spawnTime = 4f;
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
