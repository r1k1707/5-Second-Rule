using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float speed;

    private Transform player;

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null)
            return;

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}