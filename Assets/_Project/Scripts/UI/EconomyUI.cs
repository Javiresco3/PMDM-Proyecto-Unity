using TMPro;
using UnityEngine;

public class EconomyUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TMP_Text goldText;
    [SerializeField] private EconomyManager economyManager;

    private void OnEnable()
    {
        if (economyManager == null)
        {
            economyManager = EconomyManager.Instance;
        }

        if (economyManager != null)
        {
            economyManager.OnGoldChanged += UpdateGoldDisplay;
            UpdateGoldDisplay(economyManager.CurrentGold);
        }
    }

    private void Start()
    {
        if (economyManager == null && EconomyManager.Instance != null)
        {
            economyManager = EconomyManager.Instance;
            economyManager.OnGoldChanged += UpdateGoldDisplay;
        }

        if (economyManager != null)
        {
            UpdateGoldDisplay(economyManager.CurrentGold);
        }
    }

    private void OnDisable()
    {
        if (economyManager != null)
        {
            economyManager.OnGoldChanged -= UpdateGoldDisplay;
        }
    }

    private void UpdateGoldDisplay(int currentGold)
    {
        if (goldText != null)
        {
            goldText.text = $"Oro: {currentGold}";
        }
    }
}