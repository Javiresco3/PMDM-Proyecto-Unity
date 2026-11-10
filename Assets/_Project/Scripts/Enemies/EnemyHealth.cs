using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configuración de Vida")]
    [SerializeField] private int maxHealth = 3;

    private int currentHealth;

    public event Action<int, int> OnHealthChanged;
    public event Action OnDeath;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth = Mathf.Max(0, currentHealth - damage);
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnDeath?.Invoke();
        Destroy(gameObject);
    }

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
}