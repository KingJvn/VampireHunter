using UnityEngine;

public class MeleeWeapon : Weapon
{
    private Animator playerAnimator;
    private Collider2D hitbox;

    private void Awake()
    {
        playerAnimator = GetComponentInParent<Animator>();
        hitbox = GetComponentInParent<Collider2D>();
        hitbox.enabled = false;
    }
    public override void Attack()
    {
        playerAnimator.SetTrigger("Attack1");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemy))
        //{
        //    enemy.TakeDamage(damage);
        //}
    }
}
