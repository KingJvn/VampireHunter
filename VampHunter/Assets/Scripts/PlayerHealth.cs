using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    public int fullHealth = 10;
    public int currentHealth;
    public Transform respawnPoint;
    public int respawnDelay = 5;
    public TextMeshProUGUI healthText;

    private SpriteRenderer spriteRenderer;
    private Collider2D playerCollider;
    public bool isDead = false;


    private void Start()
    {
        currentHealth = fullHealth;
        UpdateHealthText();

        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }

    public void PlayerTakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player health: " + currentHealth);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Debug.Log("Player died!");
        //hides the player instead of removing them
        if (spriteRenderer != null) spriteRenderer.enabled = false;
        if (playerCollider != null) playerCollider.enabled = false;

        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(respawnDelay);

        transform.position = respawnPoint.position;
        currentHealth = fullHealth;
        UpdateHealthText();

        if (spriteRenderer != null) spriteRenderer.enabled = true;
        if (playerCollider != null) playerCollider.enabled = true;
        isDead = false;
    }

    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + currentHealth;
        }
    }
}
