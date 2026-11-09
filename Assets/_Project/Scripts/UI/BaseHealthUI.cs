using TMPro;
using UnityEngine;

public class BaseHealthUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private BaseHealth baseHealth;

    private void OnEnable()
    {
        // Enlaza la instancia si no se arrastró por Inspector
        if (baseHealth == null)
        {
            baseHealth = BaseHealth.Instance;
        }

        if (baseHealth != null)
        {
            baseHealth.OnHealthChanged += UpdateHealthDisplay;
            UpdateHealthDisplay(baseHealth.CurrentHealth, baseHealth.MaxHealth);
        }
    }

    private void Start()
    {
        // Respaldo por orden de ejecución en el primer frame
        if (baseHealth == null && BaseHealth.Instance != null)
        {
            baseHealth = BaseHealth.Instance;
            baseHealth.OnHealthChanged += UpdateHealthDisplay;
        }

        if (baseHealth != null)
        {
            UpdateHealthDisplay(baseHealth.CurrentHealth, baseHealth.MaxHealth);
        }
    }

    private void OnDisable()
    {
        // Obligatorio para evitar memory leaks (regla AGENTS.md)
        if (baseHealth != null)
        {
            baseHealth.OnHealthChanged -= UpdateHealthDisplay;
        }
    }

    private void UpdateHealthDisplay(int currentHealth, int maxHealth)
    {
        if (healthText != null)
        {
            healthText.text = $"Monolito: {currentHealth} / {maxHealth}";
        }
    }
}