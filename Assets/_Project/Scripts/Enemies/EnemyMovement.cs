using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private WaypointPath targetPath;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float reachThreshold = 0.05f;

    private int currentWaypointIndex = 0;
    private Transform currentTarget;

    private void Start()
    {
        if (targetPath == null || targetPath.WaypointCount == 0)
        {
            Debug.LogWarning($"[EnemyMovement] Falta WaypointPath o está vacío en {gameObject.name}.", this);
            enabled = false;
            return;
        }

        currentTarget = targetPath.GetWaypoint(currentWaypointIndex);

        if (currentTarget != null)
        {
            transform.position = currentTarget.position;
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
}