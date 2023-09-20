using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    int wave;
    int enemiesSpawnedThisWave;
    int maxEnemies = 8;
    int currentEnemies;
    int enemiesKilled;
    int numberOfPrefabs;


    float width;
    float height;
    float timer;
    float spawnRate = 1f;

    Vector3 randomSpawnPosition;


    // Start is called before the first frame update
    void Start()
    {
        width = Camera.main.orthographicSize * Camera.main.aspect;
        height = Camera.main.orthographicSize;

        numberOfPrefabs = enemyPrefab.Length;

    }

    void Update()
    {
        if (currentEnemies == 0)
        {
            enemiesSpawnedThisWave = 0;
            wave++;
        }

        // 1 normal enemy
        if (wave == 1)
        {
            if (enemiesSpawnedThisWave < 1)
            {
                SpawnNormalEnemy();
                enemiesSpawnedThisWave++;
            }
        }

        // 3 normal enemies
        if (wave == 2)
        {
            if (enemiesSpawnedThisWave < 3)
            {
                SpawnNormalEnemy();
                enemiesSpawnedThisWave++;
            }
        }

        // 1 abnormal enemy
        if (wave == 3)
        {
            if (enemiesSpawnedThisWave < 1)
            {
                SpawnAbnormalEnemy();
                enemiesSpawnedThisWave++;
            }
        }

        // 2 abnormal enemy
        if (wave == 4)
        {
            if (enemiesSpawnedThisWave < 2)
            {
                SpawnAbnormalEnemy();
                enemiesSpawnedThisWave++;
            }
        }

        // random spawn
        if (wave == 5)
        {
            if (timer > spawnRate && currentEnemies < maxEnemies)
            {
                SpawnRandomEnemy();
                timer = 0;
            }
        }

        if (enemiesKilled >= 20)
        {
            wave++;
            print("Trigger boss fight");
        }


        timer += Time.deltaTime;


        // Spawn Functions
        void SpawnNormalEnemy()
        {
            randomSpawnPosition = new Vector3(width, Random.Range(-height, height));
            Instantiate(enemyPrefab[1], randomSpawnPosition, transform.rotation);
            currentEnemies++;
        }

        void SpawnAbnormalEnemy()
        {
            randomSpawnPosition = new Vector3(width, Random.Range(-height, height));
            Instantiate(enemyPrefab[0], randomSpawnPosition, transform.rotation);
            currentEnemies++;
        }

        void SpawnRandomEnemy()
        {
            randomSpawnPosition = new Vector3(width, Random.Range(-height, height));
            Instantiate(enemyPrefab[Random.Range(0, numberOfPrefabs)], randomSpawnPosition, transform.rotation);
            currentEnemies++;
        }
    }
    public void Enemydied()
    {
        currentEnemies--;
        enemiesKilled++;
    }
}
