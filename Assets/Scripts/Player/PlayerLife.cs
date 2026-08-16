using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int currentHealth;

    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Player HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }
}
