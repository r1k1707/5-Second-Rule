using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform crosshair;

    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletSpeed = 10f;

    private float fireTimer;

    void Start()
    {
        fireTimer = fireRate;
    }

    void Update()
    {
        if (!GameCountdown.gameStarted)
            return;

        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        // Spawn bullet from the player
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Get direction from player to crosshair
        Vector2 shootDirection =
            (crosshair.position - transform.position).normalized;

        // Get bullet Rigidbody2D
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = shootDirection * bulletSpeed;
        }
    }
}