using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private Transform player;

    [SerializeField] private int itemAmount = 3;
    [SerializeField] private float minimumSpawnDistance = 5f;
    [SerializeField] private float maximumSpawnDistance = 10f;

    [SerializeField] private float itemSpawnRate = 5f;

    void Start()
    {
        StartCoroutine(WaitForCountdown());
    }
    IEnumerator WaitForCountdown()
    {
        // Wait until the countdown is finished
        yield return new WaitUntil(() => GameCountdown.gameStarted);

        // Start spawning items
        StartCoroutine(SpawnItems());
    }

    IEnumerator SpawnItems()
    {
        for (int i = 0; i < itemAmount; i++)
        {
            // Pick a random item from the array
            GameObject randomItem = itemPrefabs[Random.Range(0, itemPrefabs.Length)];

            // Pick a random direction around the player
            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            // Pick a random distance
            float randomDistance = Random.Range(minimumSpawnDistance, maximumSpawnDistance);

            // Calculate spawn position
            Vector2 spawnPosition = (Vector2)player.position + randomDirection * randomDistance;

            // Spawn the random item
            Instantiate(randomItem, spawnPosition, Quaternion.identity);

            yield return new WaitForSeconds(itemSpawnRate);
        }
    }
}