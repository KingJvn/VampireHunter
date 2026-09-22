using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    [SerializeField] protected int damage = 10;
    [SerializeField] protected float attackCooldown = 0.5f;

    public abstract void Attack();
}
