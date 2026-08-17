using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform player;

    [SerializeField] private float fireRate = 2f;
    [SerializeField] private float bulletSpeed = 5f;

    private float fireTimer;

    void Start()
    {
        fireTimer = fireRate;
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        // Spawn bullet from the enemy
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Get direction from enemy to player
        Vector2 shootDirection = (player.position - transform.position).normalized;

        // Get bullet Rigidbody2D
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = shootDirection * bulletSpeed;
        }
    }
}