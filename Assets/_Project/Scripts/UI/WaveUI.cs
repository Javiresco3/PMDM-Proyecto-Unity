using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private TMP_Text waveText;
    [SerializeField] private WaveManager waveManager;

    private void OnEnable()
    {
        if (waveManager == null)
        {
            waveManager = WaveManager.Instance;
        }

        if (waveManager != null)
        {
            waveManager.OnWaveChanged += HandleWaveChanged;
            waveManager.OnCountdownTick += HandleCountdownTick;
            waveManager.OnAllWavesCompleted += HandleAllWavesCompleted;
        }
    }

    private void Start()
    {
        if (waveManager == null && WaveManager.Instance != null)
        {
            waveManager = WaveManager.Instance;
            waveManager.OnWaveChanged += HandleWaveChanged;
            waveManager.OnCountdownTick += HandleCountdownTick;
            waveManager.OnAllWavesCompleted += HandleAllWavesCompleted;
        }
    }

    private void OnDisable()
    {
        if (waveManager != null)
        {
            waveManager.OnWaveChanged -= HandleWaveChanged;
            waveManager.OnCountdownTick -= HandleCountdownTick;
            waveManager.OnAllWavesCompleted -= HandleAllWavesCompleted;
        }
    }

    private void HandleWaveChanged(int currentWave, int totalWaves)
    {
        if (waveText != null)
        {
            waveText.text = $"Oleada: {currentWave} / {totalWaves}";
        }
    }

    private void HandleCountdownTick(float secondsLeft)
    {
        if (waveText != null)
        {
            waveText.text = $"Siguiente oleada: {Mathf.CeilToInt(secondsLeft)}s";
        }
    }

    private void HandleAllWavesCompleted()
    {
        if (waveText != null)
        {
            waveText.text = "¡Todas las oleadas superadas!";
        }
    }
}