using System;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    public static BaseHealth Instance { get; private set; }

    [Header("Configuración de Vidas")]
    [SerializeField] private int maxHealth = 20;

    private int currentHealth;

    public event Action<int, int> OnHealthChanged;
    public event Action OnBaseDestroyed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        currentHealth = maxHealth;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
        {
            return;
        }

        currentHealth = Mathf.Max(0, currentHealth - damage);
        Debug.Log($"[BaseHealth] ¡El Monolito ha recibido {damage} de daño! Vidas restantes: {currentHealth}/{maxHealth}");

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            Debug.LogError("[BaseHealth] ¡El Monolito ha sido destruido! GAME OVER");
            OnBaseDestroyed?.Invoke();
        }
    }

    public int CurrentHealth => currentHealth;
    public int MaxHealth => maxHealth;
}