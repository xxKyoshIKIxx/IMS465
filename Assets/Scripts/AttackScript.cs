using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AttackScript : MonoBehaviour
{

    public float attackRange = 2.0f;
    public float maxAmmo;
    public float currentAmmo;

    [SerializeField] private Text ammoText;

    void Awake()
    {
        maxAmmo = 9.0f;
        currentAmmo = maxAmmo;
    }

    void Start()
    {
        UpdateAmmo();
    }

    void Update()
    {

    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Attack();
        }
    }

    public void OnSpell(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Cast();
        }
    }

    private void Attack()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);

        foreach (Collider2D hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy Hit");

                currentAmmo++;

                if (currentAmmo > maxAmmo)
                {
                    currentAmmo = maxAmmo;
                }
            }
        }

        UpdateAmmo();
    }

    private void Cast()
    {
        if (currentAmmo >= 3)
        {
            Debug.Log("Spell Cast");
            
            currentAmmo-= 3f;
        }

        UpdateAmmo();
    }

    public void UpdateAmmo()
    {
        if (ammoText != null)
        {
            ammoText.text = $"Soul Counter: {currentAmmo} / {maxAmmo}";
        }
    }
}