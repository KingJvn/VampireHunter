using UnityEngine;

public class Enemy_Test : MonoBehaviour {
    public GameObject EnemyLoot;
    public Transform playerLocation;

    public int fullHealth;
    public int currentHealth;

    public int walkSpeed = 2;

    public int meleedamage = 1;

    public float knockbackForce = 20f;
    public bool isKnockedBack = false;
    public float knockbackDuration = 0.1f;
    private Rigidbody2D rb;



    private void Start() {
        fullHealth = Random.Range(3, 6);
        currentHealth = fullHealth;

        rb = GetComponent<Rigidbody2D>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null) {
            playerLocation = playerObject.transform;
        }
    }

    private void Update() {
        if (playerLocation != null && !isKnockedBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerLocation.position, walkSpeed * Time.deltaTime);
        }
    }

    // When the player hits an enemy with a bullet or their body
    public void TakeDamage(int amount) {
        currentHealth -= amount;
        Debug.Log(gameObject.name + " health: " + currentHealth);

        if (currentHealth <= 0) {
            Die();
        }
    }

    // When the player hits an enemy with their body this happens
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isKnockedBack)
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.PlayerTakeDamage(meleedamage);
            }

            Vector2 knockbackDirection = (transform.position - collision.transform.position).normalized;
            rb.linearVelocity = knockbackDirection * knockbackForce;

            StartCoroutine(KnockbackRoutine());
        }
    }
    private System.Collections.IEnumerator KnockbackRoutine()
    {
        isKnockedBack = true;
        Debug.Log("Knockback started");
        yield return new WaitForSeconds(knockbackDuration);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
        Debug.Log("Knockback ended");
    }
    // When the enemy dies, this happens
    public void Die() {
        Instantiate(EnemyLoot, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
