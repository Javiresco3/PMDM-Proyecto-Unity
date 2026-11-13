using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public enum GameState
    {
        Playing,
        Victory,
        Defeat
    }

    [Header("Referencias de Sistemas")]
    [SerializeField] private BaseHealth baseHealth;
    [SerializeField] private WaveManager waveManager;

    [Header("Configuración")]
    [SerializeField] private bool pauseOnGameEnd = true;

    private GameState currentState = GameState.Playing;
    private bool isSubscribed = false;

    public event Action OnVictory;
    public event Action OnDefeat;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        currentState = GameState.Playing;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        if (baseHealth == null)
        {
            baseHealth = BaseHealth.Instance;
        }

        if (waveManager == null)
        {
            waveManager = WaveManager.Instance;
        }

        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();
        Time.timeScale = 1f;

        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void SubscribeToEvents()
    {
        if (isSubscribed)
        {
            return;
        }

        if (baseHealth != null)
        {
            baseHealth.OnHealthChanged += HandleBaseHealthChanged;
        }

        if (waveManager != null)
        {
            waveManager.OnAllWavesCompleted += HandleAllWavesCompleted;
        }

        isSubscribed = true;
    }

    private void UnsubscribeFromEvents()
    {
        if (!isSubscribed)
        {
            return;
        }

        if (baseHealth != null)
        {
            baseHealth.OnHealthChanged -= HandleBaseHealthChanged;
        }

        if (waveManager != null)
        {
            waveManager.OnAllWavesCompleted -= HandleAllWavesCompleted;
        }

        isSubscribed = false;
    }

    private void HandleBaseHealthChanged(int currentHealth, int maxHealth)
    {
        if (currentHealth <= 0)
        {
            TriggerDefeat();
        }
    }

    private void HandleAllWavesCompleted()
    {
        TriggerVictory();
    }

    public void TriggerVictory()
    {
        if (currentState != GameState.Playing)
        {
            return;
        }

        currentState = GameState.Victory;

        if (pauseOnGameEnd)
        {
            Time.timeScale = 0f;
        }

        OnVictory?.Invoke();
    }

    public void TriggerDefeat()
    {
        if (currentState != GameState.Playing)
        {
            return;
        }

        currentState = GameState.Defeat;

        if (pauseOnGameEnd)
        {
            Time.timeScale = 0f;
        }

        OnDefeat?.Invoke();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public GameState CurrentState => currentState;
    public bool IsGameOver => currentState != GameState.Playing;
}