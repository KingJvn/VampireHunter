using UnityEngine;
using TMPro;

public class PlayerLoot : MonoBehaviour {
    public int totalCoins = 0;
    public TextMeshProUGUI coinText;

    private void Start() {
        UpdateCoinText();
    }
    public void AddCoins(int amount) {
        totalCoins += amount;
        UpdateCoinText();
        Debug.Log("Money: " + totalCoins);
    }
    private void UpdateCoinText() {
        coinText.text = "Coins: " + totalCoins;
    }
}