using System;
using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager Instance { get; private set; }

    [System.Serializable]
    public class Wave
    {
        [SerializeField] private string waveName = "Oleada 1";
        [SerializeField] private EnemyMovement enemyPrefab;
        [SerializeField] private int enemyCount = 5;
        [SerializeField] private float spawnRate = 1.5f;

        public string WaveName => waveName;
        public EnemyMovement EnemyPrefab => enemyPrefab;
        public int EnemyCount => enemyCount;
        public float SpawnRate => spawnRate;
    }

    public enum WaveState
    {
        WaitingToStart,
        Spawning,
        WaveInProgress,
        Cooldown,
        Completed
    }

    [Header("Configuración de Oleadas")]
    [SerializeField] private Wave[] waves;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private WaypointPath waypointPath;

    private int currentWaveIndex = 0;
    private int activeEnemies = 0;
    private WaveState currentState = WaveState.WaitingToStart;
    private float countdownTimer = 0f;

    public event Action<int, int> OnWaveChanged;
    public event Action<float> OnCountdownTick;
    public event Action OnAllWavesCompleted;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        if (waves == null || waves.Length == 0)
        {
            Debug.LogWarning("[WaveManager] No hay oleadas configuradas en el Inspector.");
            return;
        }

        countdownTimer = timeBetweenWaves;
        currentState = WaveState.Cooldown;
    }

    private void Update()
    {
        if (currentState == WaveState.Cooldown)
        {
            countdownTimer -= Time.deltaTime;
            OnCountdownTick?.Invoke(Mathf.Max(0f, countdownTimer));

            if (countdownTimer <= 0f)
            {
                StartNextWave();
            }
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void StartNextWave()
    {
        if (currentWaveIndex >= waves.Length)
        {
            currentState = WaveState.Completed;
            OnAllWavesCompleted?.Invoke();
            return;
        }

        OnWaveChanged?.Invoke(currentWaveIndex + 1, waves.Length);
        StartCoroutine(SpawnWaveRoutine(waves[currentWaveIndex]));
    }

    private IEnumerator SpawnWaveRoutine(Wave wave)
    {
        currentState = WaveState.Spawning;

        for (int i = 0; i < wave.EnemyCount; i++)
        {
            SpawnEnemy(wave.EnemyPrefab);
            yield return new WaitForSeconds(wave.SpawnRate);
        }

        currentState = WaveState.WaveInProgress;
    }

    private void SpawnEnemy(EnemyMovement prefab)
    {
        if (prefab == null || waypointPath == null)
        {
            return;
        }

        Transform firstWaypoint = waypointPath.GetWaypoint(0);
        if (firstWaypoint == null)
        {
            return;
        }

        EnemyMovement newEnemy = Instantiate(prefab, firstWaypoint.position, Quaternion.identity);
        newEnemy.SetPath(waypointPath);
        activeEnemies++;
    }

    public void OnEnemyDefeated()
    {
        activeEnemies = Mathf.Max(0, activeEnemies - 1);

        if (currentState == WaveState.WaveInProgress && activeEnemies == 0)
        {
            currentWaveIndex++;

            if (currentWaveIndex >= waves.Length)
            {
                currentState = WaveState.Completed;
                OnAllWavesCompleted?.Invoke();
            }
            else
            {
                currentState = WaveState.Cooldown;
                countdownTimer = timeBetweenWaves;
            }
        }
    }

    public int CurrentWaveIndex => currentWaveIndex;
    public int TotalWaves => waves != null ? waves.Length : 0;
    public WaveState CurrentState => currentState;
}