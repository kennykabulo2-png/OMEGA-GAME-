using System;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Took damage: " + amount + " Current health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log("Healed: " + amount + " Current health: " + currentHealth);
    }

    private void Die()
    {
        Debug.Log("Character has died.");
        // Handle death (e.g. trigger death animation, disable character, etc.)
    }
}
