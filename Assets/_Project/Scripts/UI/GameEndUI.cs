using UnityEngine;
using UnityEngine.UI;

public class GameEndUI : MonoBehaviour
{
    [Header("Paneles de Fin de Partida")]
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject defeatPanel;

    [Header("Botones de Reinicio")]
    [SerializeField] private Button victoryRestartButton;
    [SerializeField] private Button defeatRestartButton;

    [Header("Referencias")]
    [SerializeField] private GameManager gameManager;

    private bool isSubscribed = false;

    private void Awake()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }

        if (defeatPanel != null)
        {
            defeatPanel.SetActive(false);
        }

        if (victoryRestartButton != null)
        {
            victoryRestartButton.onClick.AddListener(HandleRestartClicked);
        }

        if (defeatRestartButton != null)
        {
            defeatRestartButton.onClick.AddListener(HandleRestartClicked);
        }
    }

    private void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }

        SubscribeToEvents();
    }

    private void OnDestroy()
    {
        UnsubscribeFromEvents();

        if (victoryRestartButton != null)
        {
            victoryRestartButton.onClick.RemoveListener(HandleRestartClicked);
        }

        if (defeatRestartButton != null)
        {
            defeatRestartButton.onClick.RemoveListener(HandleRestartClicked);
        }
    }

    private void SubscribeToEvents()
    {
        if (isSubscribed || gameManager == null)
        {
            return;
        }

        gameManager.OnVictory += HandleVictory;
        gameManager.OnDefeat += HandleDefeat;
        isSubscribed = true;
    }

    private void UnsubscribeFromEvents()
    {
        if (!isSubscribed || gameManager == null)
        {
            return;
        }

        gameManager.OnVictory -= HandleVictory;
        gameManager.OnDefeat -= HandleDefeat;
        isSubscribed = false;
    }

    private void HandleVictory()
    {
        if (defeatPanel != null)
        {
            defeatPanel.SetActive(false);
        }

        if (victoryPanel != null)
        {
            victoryPanel.SetActive(true);
        }
    }

    private void HandleDefeat()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }

        if (defeatPanel != null)
        {
            defeatPanel.SetActive(true);
        }
    }

    private void HandleRestartClicked()
    {
        if (gameManager != null)
        {
            gameManager.RestartGame();
        }
        else if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGame();
        }
    }
}