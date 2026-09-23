using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputActionReference attack;
    [SerializeField] private Weapon equippedWeapon;
    private float lastAttackTime = 0f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnAttack(InputAction.CallbackContext obj)
    {
        if (!obj.started || equippedWeapon == null) return;

        if (equippedWeapon is MeleeWeapon)
        {

            if (Time.time >= lastAttackTime + equippedWeapon.AttackCooldown)
            {
                lastAttackTime = Time.time;

                animator.SetTrigger("Swing"); //trigger animation

                equippedWeapon.Attack(); //trigger attack logic
            }
        }
    }

    private void OnEnable()
    {
        attack.action.started += OnAttack;
    }
    private void OnDisable()
    {
        attack.action.started -= OnAttack;
    }
}
