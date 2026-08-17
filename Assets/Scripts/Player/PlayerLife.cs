using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 10;

    private int currentHealth;

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Image healthBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Debug.Log("Player HP: " + currentHealth);

        StartCoroutine(DamageFlash());
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    public void Die()
    {
        Destroy(gameObject);
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    IEnumerator DamageFlash()
    {
        for (int i = 0; i < 2; i++)
        {
            spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(0.1f);
        }
    }
}
