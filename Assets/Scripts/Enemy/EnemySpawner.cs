using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int enemyAmount = 100;
    [SerializeField] private float enemySpawnRate = 1f;

    [SerializeField] private Transform player;
    [SerializeField] private float minimumSpawnDistance = 5f;
    [SerializeField] private float maximumSpawnDistance = 10f;

    // How much space the enemy needs around its spawn point
    [SerializeField] private float spawnCheckRadius = 0.5f;

    // How many times the spawner will try to find a safe position
    [SerializeField] private int maxSpawnAttempts = 20;

    void Start()
    {
        // Don't start spawning during countdown
        if (!GameCountdown.gameStarted)
        {
            StartCoroutine(WaitForCountdown());
        }
        else
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator WaitForCountdown()
    {
        // Wait until the countdown finishes
        yield return new WaitUntil(() => GameCountdown.gameStarted);

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemyAmount; i++)
        {
            Vector2 spawnPosition = Vector2.zero;
            bool validPosition = false;

            // Try to find a safe spawn position
            for (int attempt = 0; attempt < maxSpawnAttempts; attempt++)
            {
                // Pick a random direction around the player
                Vector2 randomDirection = Random.insideUnitCircle.normalized;

                // Pick a random distance from the player
                float randomDistance = Random.Range(minimumSpawnDistance, maximumSpawnDistance);

                // Calculate spawn position
                spawnPosition = (Vector2)player.position + randomDirection * randomDistance;

                // Check everything around the spawn position
                Collider2D[] colliders = Physics2D.OverlapCircleAll(spawnPosition, spawnCheckRadius);

                // Assume the position is safe
                validPosition = true;

                foreach (Collider2D collider in colliders)
                {
                    // Don't spawn inside obstacles
                    if (collider.CompareTag("Obstacles"))
                    {
                        validPosition = false;
                        break;
                    }

                    // Don't spawn directly on another enemy
                    if (collider.CompareTag("Enemy"))
                    {
                        validPosition = false;
                        break;
                    }
                }

                // If the position is safe, just add break
                if (validPosition)
                {
                    break;
                }
            }

            // Only spawn if a safe position was found
            if (validPosition)
            {
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            // Wait before spawning the next enemy
            yield return new WaitForSeconds(enemySpawnRate);
        }
    }
}