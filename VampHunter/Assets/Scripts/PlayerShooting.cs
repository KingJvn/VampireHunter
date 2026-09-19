using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class PlayerShooting : MonoBehaviour {
    public GameObject Bullet;
    public Transform launchPoint; // Bullet spawn

    public int chamberSlots = 6; // Bullets before reload
    public int currentAmmo; 
    public bool isReloading = false; 
    public int reloadTime = 2; // reload time in seconds

    public TextMeshProUGUI ammoText;

    private void Start() {
        currentAmmo = chamberSlots;
        UpdateAmmoText();
    }


    private void Update() {
        if (Mouse.current.leftButton.wasPressedThisFrame) { // Left Mouse for shooting
            Shoot();
        }
        if (Keyboard.current.rKey.wasPressedThisFrame && !isReloading && currentAmmo < chamberSlots) { // R for reloading
            StartCoroutine(Reload());
        }
    }

    private void Shoot()
    {
        if (currentAmmo > 0) {
            GameObject bullet = Instantiate(Bullet, launchPoint.position, Quaternion.identity); // Spawn Bullet
            Projectile projectileScript = bullet.GetComponent<Projectile>(); // Pulls Projectile Script to dictate bullet movement
            projectileScript.SetDirection(transform.up); // Sets bullet in a direction... in this case up where the tip of the triangle is

            currentAmmo--;
            UpdateAmmoText();
        }
    }

    private IEnumerator Reload() {
        isReloading = true;
        ammoText.text = "Reloading...";

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = chamberSlots;
        isReloading = false;
        UpdateAmmoText();
    }

    private void UpdateAmmoText() {
        ammoText.text = "Ammo: " + currentAmmo + "/" + chamberSlots;
    }
}
