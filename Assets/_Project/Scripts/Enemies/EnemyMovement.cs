using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Configuración de Ruta y Movimiento")]
    [SerializeField] private WaypointPath targetPath;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float reachThreshold = 0.05f;

    [Header("Visual")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [Tooltip("Marca esta casilla si el sprite original de la textura mira hacia la derecha.")]
    [SerializeField] private bool facesRightByDefault = true;

    private int currentWaypointIndex = 0;
    private Transform currentTarget;

    private void Awake()
    {
        // Caché defensivo en inicialización (nunca en Update)
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        if (targetPath == null || targetPath.WaypointCount == 0)
        {
            return;
        }

        InitTarget();
    }

    public void SetPath(WaypointPath path)
    {
        targetPath = path;
        currentWaypointIndex = 0;

        if (targetPath != null && targetPath.WaypointCount > 0)
        {
            InitTarget();
        }
    }

    private void InitTarget()
    {
        currentTarget = targetPath.GetWaypoint(currentWaypointIndex);
        if (currentTarget != null)
        {
            transform.position = currentTarget.position;
            UpdateFacingDirection();
        }
    }

    private void Update()
    {
        if (currentTarget == null)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            currentTarget.position,
            moveSpeed * Time.deltaTime
        );

        UpdateFacingDirection();

        if (Vector3.Distance(transform.position, currentTarget.position) <= reachThreshold)
        {
            currentWaypointIndex++;

            if (currentWaypointIndex >= targetPath.WaypointCount)
            {
                Destroy(gameObject);
            }
            else
            {
                currentTarget = targetPath.GetWaypoint(currentWaypointIndex);
            }
        }
    }

    private void UpdateFacingDirection()
    {
        if (spriteRenderer == null || currentTarget == null)
        {
            return;
        }

        float deltaX = currentTarget.position.x - transform.position.x;

        // Margen mínimo para evitar parpadeos si se mueve puramente en vertical
        if (Mathf.Abs(deltaX) > 0.01f)
        {
            bool movingRight = deltaX > 0f;
            spriteRenderer.flipX = facesRightByDefault ? !movingRight : movingRight;
        }
    }
}