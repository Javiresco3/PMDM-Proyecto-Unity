using System;
using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    public static EconomyManager Instance { get; private set; }

    [Header("Configuración Inicial")]
    [SerializeField] private int startingGold = 100;

    private int currentGold;

    public event Action<int> OnGoldChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        currentGold = startingGold;
    }

    private void Start()
    {
        OnGoldChanged?.Invoke(currentGold);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void AddGold(int amount)
    {
        if (amount <= 0)
        {
            return;
        }

        currentGold += amount;
        OnGoldChanged?.Invoke(currentGold);
    }

    public bool CanAfford(int amount)
    {
        return currentGold >= amount;
    }

    public bool SpendGold(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (!CanAfford(amount))
        {
            return false;
        }

        currentGold -= amount;
        OnGoldChanged?.Invoke(currentGold);
        return true;
    }

    public int CurrentGold => currentGold;
}