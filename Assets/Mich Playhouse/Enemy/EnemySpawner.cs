using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    int wave;
    int enemySpawnedThisWave;
    bool spawnNextWave;
    //int maxEnemies = 6;
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
        //if (currentEnemies == 0)
        //{
        //    // Invoke("SpawnNextWave", 1);
        //}

        // 1 normal enemy
        if (wave == 1 && spawnNextWave)
        {
            enemySpawnedThisWave = 0;
            while (enemySpawnedThisWave < 1)
            {
                SpawnNormalEnemy();
                enemySpawnedThisWave++;
            }
            wave++;
            spawnNextWave = false;
        }

        // 3 normal enemies
        if (wave == 2 && spawnNextWave)
        {
            enemySpawnedThisWave = 0;
            while (enemySpawnedThisWave < 3)
            {
                Invoke("SpawnNormalEnemy", spawnRate);
            }
            wave++;
            spawnNextWave = false;
        }

        // 1 abnormal enemy
        if (wave == 3 && spawnNextWave) 
        {
            enemySpawnedThisWave = 0;
            while (enemySpawnedThisWave < 1)
            {
                Invoke("SpawnAbnormalEnemy", spawnRate);
            }
            wave++;
            spawnNextWave = false;
        }

        // 2 abnormal enemy
        if (wave == 4 && spawnNextWave)
        {
            enemySpawnedThisWave = 0;
            while (enemySpawnedThisWave < 2)
            {
                Invoke("SpawnAbnormalEnemy", spawnRate);
            }
            wave++;
            spawnNextWave = false;
        }

        // random spawn
        if (wave == 5 && spawnNextWave)
        {
            if (timer > spawnRate)
            {
                SpawnRandomEnemy();
                timer = 0;
                currentEnemies++;
            }
        }

        if (enemiesKilled >= 30)
        {
            wave++;
            print("Trigger boss fight");
        }


        timer += Time.deltaTime;


        // Spawn Functions
        randomSpawnPosition = new Vector3(width, Random.Range(-height, height));

        void SpawnNormalEnemy()
        {
            Instantiate(enemyPrefab[1], randomSpawnPosition, transform.rotation);
            currentEnemies++;
        }

        void SpawnAbnormalEnemy()
        {
            Instantiate(enemyPrefab[0], randomSpawnPosition, transform.rotation);
            currentEnemies++;
        }

        void SpawnRandomEnemy()
        {
            Instantiate(enemyPrefab[Random.Range(0, numberOfPrefabs)], randomSpawnPosition, transform.rotation);
            currentEnemies++;
        }
    }
    public void Enemydied()
    {
        currentEnemies--;
    }
    void SpawnNextWave()
    {
        spawnNextWave = true;
    }
}
