using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public float lifetime = 2f;

    [SerializeField] private int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerLife playerLife = collision.GetComponentInParent<PlayerLife>();

            if (playerLife != null)
            {
                playerLife.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}