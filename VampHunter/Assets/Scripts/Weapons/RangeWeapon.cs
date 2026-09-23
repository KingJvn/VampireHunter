using UnityEngine;

public class RangeWeapon : Weapon
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 15f;
    //add bullet spread at some point
    public override void Attack()
    {
        throw new System.NotImplementedException();
    }
}
