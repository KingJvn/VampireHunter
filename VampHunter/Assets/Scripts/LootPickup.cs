using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class LootPickup : MonoBehaviour {
    // When the player walks over coin this happens
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision) {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player")) {
            int CoinValue = Random.Range(1, 11);
            PlayerLoot totalCoins = collision.gameObject.GetComponent<PlayerLoot>();
            totalCoins.AddCoins(CoinValue);
            Destroy(gameObject);
        }
    }
}
