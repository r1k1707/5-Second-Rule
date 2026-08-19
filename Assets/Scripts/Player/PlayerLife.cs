using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float invincibilityTime = 0.5f;

    private int currentHealth;
    private bool isInvincible = false;

    [SerializeField] private Image healthBar;
    [SerializeField] private GameOverManager gameOverManager;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        currentHealth = maxHealth;

        spriteRenderer = GetComponent<SpriteRenderer>();

        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        // Don't take damage while invincible (duh)
        if (isInvincible || GetComponent<PlayerMovement>().IsDashing)
            return;

        currentHealth -= damage;

        Debug.Log("Player HP: " + currentHealth);

        UpdateHealthBar();

        // Start invincibility during the flash
        StartCoroutine(DamageFlash());

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthBar();
        Debug.Log("get that dough");
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    private void Die()
    {
        Debug.Log("bro...");
        gameOverManager.GameOver();
    }

    IEnumerator DamageFlash()
    {
        isInvincible = true;

        float timer = 0f;

        while (timer < invincibilityTime)
        {
            spriteRenderer.color = Color.red;

            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(0.1f);

            timer += 0.2f;
        }

        spriteRenderer.color = Color.white;
        isInvincible = false;
    }
}