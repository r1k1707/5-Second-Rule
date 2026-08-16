using System.Collections;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    public bool isHit = false;
    public float timeToColor;
    SpriteRenderer sr;
    Color defaultColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        defaultColor = sr.color;
        sr = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (!isHit)
        {
            isHit = true;
            StartCoroutine("SwitchColor");
        }
        currentHealth -= damage;

        Debug.Log("Enemy HP: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    IEnumerator SwitchColor()
    {
        sr.color = new Color(1f, 0.30196078f, 0.30196078f);
        yield return new WaitForSeconds(timeToColor);
        sr.color = defaultColor;
        isHit = false;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}