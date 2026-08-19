using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        Heal,
        DamageBoost,
        FireRateBoost
    }

    [SerializeField] private ItemType itemType;

    [SerializeField] private int amount = 1;
    [SerializeField] private float duration = 5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        PlayerLife playerLife = collision.GetComponent<PlayerLife>();
        PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();
        PlayerShoot playerShoot = collision.GetComponent<PlayerShoot>();

        switch (itemType)
        {
            case ItemType.Heal:

                if (playerLife != null)
                {
                    playerLife.Heal(amount);
                    Destroy(gameObject);
                }
                break;

            case ItemType.DamageBoost:

                if (playerShoot != null)
                {
                    playerShoot.DamageBoost(amount, duration);
                    Destroy(gameObject);
                }
                break;

            case ItemType.FireRateBoost:

                if (playerShoot != null)
                {
                    playerShoot.FireRateBoost(0.8f, duration);
                    Destroy(gameObject);
                }
                break;
        }
    }
}