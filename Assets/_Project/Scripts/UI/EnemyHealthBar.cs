using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private Slider healthSlider;
    [SerializeField] private EnemyHealth enemyHealth;

    private void Awake()
    {
        FindReferences();
    }

    private void OnEnable()
    {
        FindReferences();

        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged += HandleHealthChanged;
            UpdateBar(enemyHealth.CurrentHealth, enemyHealth.MaxHealth);
        }
    }

    private void Start()
    {
        if (enemyHealth != null)
        {
            UpdateBar(enemyHealth.CurrentHealth, enemyHealth.MaxHealth);
        }
    }

    private void OnDisable()
    {
        if (enemyHealth != null)
        {
            enemyHealth.OnHealthChanged -= HandleHealthChanged;
        }
    }

    private void FindReferences()
    {
        // Autorrecuperación defensiva de referencias si no se arrastraron en el Inspector
        if (healthSlider == null)
        {
            healthSlider = GetComponent<Slider>();
            if (healthSlider == null)
            {
                healthSlider = GetComponentInChildren<Slider>();
            }
        }

        if (enemyHealth == null)
        {
            enemyHealth = GetComponentInParent<EnemyHealth>();
            if (enemyHealth == null)
            {
                enemyHealth = GetComponent<EnemyHealth>();
            }
        }
    }

    private void HandleHealthChanged(int currentHealth, int maxHealth)
    {
        UpdateBar(currentHealth, maxHealth);
    }

    private void UpdateBar(int currentHealth, int maxHealth)
    {
        if (healthSlider == null || maxHealth <= 0)
        {
            return;
        }

        // Configuración directa con números enteros reales para evitar redondeos erróneos de 0 a 1
        healthSlider.minValue = 0f;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}