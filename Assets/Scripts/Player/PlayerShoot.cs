using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform crosshair;

    [SerializeField] private float fireRate = 1f;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private int damage = 1;

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
        Bullets bulletScript = bullet.GetComponent<Bullets>();

        if (bulletScript != null)
        {
            bulletScript.SetDamage(damage);
        }

        // Get direction from player to crosshair
        Vector2 shootDirection = (crosshair.position - transform.position).normalized;

        // Get bullet Rigidbody2D
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            rb.linearVelocity = shootDirection * bulletSpeed;
        }
    }
    #region Item_BOOSTS
    public void DamageBoost(int amount, float duration)
    {
        StartCoroutine(DamageBoostCoroutine(amount, duration));
    }

    private IEnumerator DamageBoostCoroutine(int amount, float duration)
    {
        int originalDamage = damage;

        damage += amount;

        yield return new WaitForSeconds(duration);

        damage = originalDamage;
    }
    public void FireRateBoost(float amount, float duration)
    {
        StartCoroutine(FireRateBoostCoroutine(amount, duration));
    }

    private IEnumerator FireRateBoostCoroutine(float amount, float duration)
    {
        float originalFireRate = fireRate;

        fireRate -= amount;
        fireRate = Mathf.Max(fireRate, 0.05f);// Prevent the fire rate from becoming too fast

        yield return new WaitForSeconds(duration);

        fireRate = originalFireRate;
    }
    #endregion
}