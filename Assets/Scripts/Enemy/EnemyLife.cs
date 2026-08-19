using System.Collections;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    private SpriteRenderer spriteRenderer;
    private PointManager pointManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        pointManager = FindFirstObjectByType<PointManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine(DamageFlash());

        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        if (pointManager != null)
        {
            pointManager.UpdateScore(100);
        }
        VictoryMenu victoryManager = FindFirstObjectByType<VictoryMenu>();

        if (victoryManager != null)
        {
            victoryManager.EnemyDefeated();
        }
        Destroy(gameObject);
    }

    IEnumerator DamageFlash()
    {
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = new Color32(124, 155, 255, 255);   
            yield return new WaitForSeconds(0.1f);
        }
    }
}