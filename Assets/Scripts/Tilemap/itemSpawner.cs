using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    [Header("Objects to Spawn")]
    public GameObject[] objectsToSpawn;

    [Header("Spawn Settings")]
    public int numberOfObjects = 50;
    public float areaWidth = 50f;
    public float areaHeight = 50f;

    [Header("Spacing")]
    public float minimumDistance = 1.5f;

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        int spawnedObjects = 0;
        int attempts = 0;

        while (spawnedObjects < numberOfObjects && attempts < numberOfObjects * 20)
        {
            attempts++;

            float randomX = Random.Range(
                transform.position.x - areaWidth / 2,
                transform.position.x + areaWidth / 2
            );

            float randomY = Random.Range(
                transform.position.y - areaHeight / 2,
                transform.position.y + areaHeight / 2
            );

            Vector2 spawnPosition = new Vector2(randomX, randomY);

            // Check if something is already there
            Collider2D existingObject = Physics2D.OverlapCircle(
                spawnPosition,
                minimumDistance
            );

            if (existingObject != null)
            {
                continue;
            }

            GameObject objectToSpawn =
                objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            Instantiate(
                objectToSpawn,
                spawnPosition,
                Quaternion.identity
            );

            spawnedObjects++;
        }
    }
}