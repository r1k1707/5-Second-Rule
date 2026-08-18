using UnityEngine;
using UnityEngine.Tilemaps;

public class InfiniteTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase floorTile;
    public Transform player;

    public int chunkSize = 20;
    public int renderDistance = 2;

    private Vector2Int currentChunk;

    void Start()
    {
        GenerateChunks();
    }

    void Update()
    {
        Vector2Int newChunk = new Vector2Int(
            Mathf.FloorToInt(player.position.x / chunkSize),
            Mathf.FloorToInt(player.position.y / chunkSize)
        );

        if (newChunk != currentChunk)
        {
            currentChunk = newChunk;
            GenerateChunks();
        }
    }

    void GenerateChunks()
    {
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                GenerateChunk(
                    currentChunk.x + x,
                    currentChunk.y + y
                );
            }
        }
    }

    void GenerateChunk(int chunkX, int chunkY)
    {
        int startX = chunkX * chunkSize;
        int startY = chunkY * chunkSize;

        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                Vector3Int position = new Vector3Int(
                    startX + x,
                    startY + y,
                    0
                );

                if (!tilemap.HasTile(position))
                {
                    tilemap.SetTile(position, floorTile);
                }
            }
        }
    }
}