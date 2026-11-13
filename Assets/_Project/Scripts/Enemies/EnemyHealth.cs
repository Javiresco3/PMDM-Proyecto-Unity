using System;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("Configuración de Vida")]
    [SerializeField] private int maxHealth = 3;

    [Header("Recompensa Económica")]
    [SerializeField] private int goldReward = 10;

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

            if (EconomyManager.Instance != null)
            {
                EconomyManager.Instance.AddGold(goldReward);
            }

            if (WaveManager.Instance != null)
            {
                WaveManager.Instance.OnEnemyDefeated();
            }

            Destroy(gameObject);
        }

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
    public int GoldReward => goldReward;
}