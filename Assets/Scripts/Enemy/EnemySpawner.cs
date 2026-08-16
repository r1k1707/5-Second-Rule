using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab; // Place enemy prefab in here
    [SerializeField] int enemyAmount;
    [SerializeField] private float enemySpawnRate; // Time between spawns - can edit the amount

    [SerializeField] private Transform player;
    [SerializeField] private float minimumSpawnDistance = 5f;
    [SerializeField] private float maximumSpawnDistance = 10f;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }


    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            // Pick a random direction around the player
            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            // Pick a random distance
            float randomDistance = Random.Range(minimumSpawnDistance, maximumSpawnDistance);

            // Calculate spawn position
            Vector2 spawnPosition =
                (Vector2)player.position + randomDirection * randomDistance;

            // Spawn enemy
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(enemySpawnRate);
        }
    }
}