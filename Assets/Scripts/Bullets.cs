using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float lifetime = 2f;

    [SerializeField] private int damage = 1;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyLife enemyLife = collision.GetComponentInParent<EnemyLife>();

            if (enemyLife != null)
            {
                enemyLife.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
        if (collision.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}