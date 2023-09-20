using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    int maxEnemies = 6;
    int currentEnemies;
    int numberOfPrefabs;

    float width;
    float height;
    float timer;
    float spawnRate = 1.2f;


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
        if (timer > spawnRate && currentEnemies < maxEnemies)
        {
            SpawnEnemy();
            timer = 0;
            currentEnemies++;
        }

        timer += Time.deltaTime;

        randomSpawnPosition = new Vector3(width, Random.Range(-height, height));

        void SpawnEnemy()
        {
            Instantiate(enemyPrefab[Random.Range(0, numberOfPrefabs)], randomSpawnPosition, transform.rotation);
        }
    }
    public void Enemydied()
    {
        currentEnemies--;
    }
}
