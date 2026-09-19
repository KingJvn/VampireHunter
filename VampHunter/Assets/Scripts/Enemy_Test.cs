using UnityEngine;

public class Enemy_Test : MonoBehaviour {
    public int fullHealth;
    public int currentHealth;

    private void Start() {
        fullHealth = Random.Range(3, 6);
        currentHealth = fullHealth;
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
    public void OnCollisionEnter2D(UnityEngine.Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")) {
            TakeDamage(1);
        }
    }
    // When the enemy dies, this happens
    public GameObject EnemyLoot;
    public void Die() {
        Instantiate(EnemyLoot, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
