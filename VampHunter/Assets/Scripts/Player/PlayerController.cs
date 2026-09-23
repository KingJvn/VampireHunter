using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Weapon equippedWeapon;

    private int comboStep = 0;
    private float lastAttackTime = 0f;
    [SerializeField] private float comboResetTime = 1f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Time.time - lastAttackTime > comboResetTime && comboStep > 0)
        {
            ResetCombo();
        }
    }

    public void OnAttack(InputValue value)
    {
        if (value.isPressed || equippedWeapon == null) return;

        if(Time.time >= lastAttackTime + equippedWeapon.AttackCooldown)
        {
            if(equippedWeapon is MeleeWeapon)
            {
                comboStep++;
                if (comboStep > 2) comboStep = 1;
            }
            else
            {
                comboStep = 1;
            }

            lastAttackTime = Time.time;

            animator.SetInteger("ComboStep", comboStep);
            animator.SetTrigger("Attack");

            equippedWeapon.Attack();
        }
    }

    public void ResetCombo()
    {
        comboStep = 0;
        animator.SetInteger("ComboStep", 0);
    }
}
