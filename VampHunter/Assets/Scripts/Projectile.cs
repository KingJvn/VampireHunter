using UnityEngine;

public class Projectile : MonoBehaviour {
    public int speed = 10;
    public int damage = 1;
    private Vector2 direction = Vector2.up;
    public void SetDirection(Vector2 newDirection){ // Setting where bullets go
        direction = newDirection.normalized;
    }
    private void Update() {
        transform.Translate(direction * speed * Time.deltaTime); // How bullets move
    }

    // When a bullet hits an enemy
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy")) {
            Enemy_Test enemy = other.GetComponent<Enemy_Test>();
            if (enemy != null) {
                enemy.TakeDamage(damage); 
            }
            Destroy(gameObject);
        }
    }
}

