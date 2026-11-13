using System;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager Instance { get; private set; }

    [System.Serializable]
    public class TowerBlueprint
    {
        [SerializeField] private string towerName = "Esbirro Básico";
        [SerializeField] private Tower towerPrefab;
        [SerializeField] private int cost = 50;

        public string TowerName => towerName;
        public Tower TowerPrefab => towerPrefab;
        public int Cost => cost;
    }

    [Header("Torre Seleccionada")]
    [SerializeField] private TowerBlueprint selectedTower;

    public event Action<Tower, TowerSlot> OnTowerBuilt;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public bool CanBuild => selectedTower != null && selectedTower.TowerPrefab != null;

    public bool HasEnoughGold()
    {
        if (!CanBuild || EconomyManager.Instance == null)
        {
            return false;
        }

        return EconomyManager.Instance.CanAfford(selectedTower.Cost);
    }

    public void SelectTowerToBuild(TowerBlueprint blueprint)
    {
        selectedTower = blueprint;
    }

    public bool BuildTowerOn(TowerSlot slot)
    {
        if (slot == null || slot.IsOccupied || !CanBuild)
        {
            return false;
        }

        if (EconomyManager.Instance == null)
        {
            return false;
        }

        if (!EconomyManager.Instance.SpendGold(selectedTower.Cost))
        {
            return false;
        }

        Tower newTower = Instantiate(selectedTower.TowerPrefab, slot.GetBuildPosition(), Quaternion.identity);
        slot.SetOccupied(newTower);
        OnTowerBuilt?.Invoke(newTower, slot);

        return true;
    }

    public TowerBlueprint SelectedTower => selectedTower;
}