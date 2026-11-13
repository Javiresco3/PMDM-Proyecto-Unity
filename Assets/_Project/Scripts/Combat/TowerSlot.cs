using UnityEngine;
using UnityEngine.EventSystems;

public class TowerSlot : MonoBehaviour
{
    [Header("Referencias Visuales")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Color hoverCanAffordColor = new Color(0.6f, 1f, 0.6f, 1f);
    [SerializeField] private Color hoverCannotAffordColor = new Color(1f, 0.5f, 0.5f, 1f);

    [Header("Ajuste de Posición")]
    [SerializeField] private Vector3 buildOffset = Vector3.zero;

    private Color defaultColor;
    private Tower builtTower;

    public bool IsOccupied => builtTower != null;

    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer != null)
        {
            defaultColor = spriteRenderer.color;
        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + buildOffset;
    }

    public void SetOccupied(Tower tower)
    {
        builtTower = tower;

        if (spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor;
        }
    }

    private void OnMouseEnter()
    {
        if (IsOccupied || spriteRenderer == null)
        {
            return;
        }

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (BuildManager.Instance != null && BuildManager.Instance.CanBuild)
        {
            spriteRenderer.color = BuildManager.Instance.HasEnoughGold()
                ? hoverCanAffordColor
                : hoverCannotAffordColor;
        }
    }

    private void OnMouseExit()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = defaultColor;
        }
    }

    private void OnMouseDown()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (IsOccupied)
        {
            return;
        }

        if (BuildManager.Instance != null)
        {
            BuildManager.Instance.BuildTowerOn(this);
        }
    }
}