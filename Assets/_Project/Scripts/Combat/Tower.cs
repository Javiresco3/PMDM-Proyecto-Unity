using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Detección y Rango")]
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private LayerMask enemyLayer;

    [Header("Disparo")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f;

    private float fireCooldown = 0f;
    private Transform currentTarget;
    private readonly Collider2D[] hitBuffer = new Collider2D[10];
    private ContactFilter2D enemyContactFilter;

    private void Awake()
    {
        ConfigureContactFilter();
    }

    private void OnValidate()
    {
        ConfigureContactFilter();
    }

    private void ConfigureContactFilter()
    {
        enemyContactFilter = new ContactFilter2D();
        enemyContactFilter.SetLayerMask(enemyLayer);
        enemyContactFilter.useTriggers = true;
    }

    private void Update()
    {
        fireCooldown -= Time.deltaTime;

        if (currentTarget == null || !currentTarget.gameObject.activeInHierarchy || !IsTargetInRange(currentTarget))
        {
            currentTarget = FindTarget();
        }

        if (currentTarget != null && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    private Transform FindTarget()
    {
        // Sobrecarga sin asignación de memoria (reemplaza al obsoleto OverlapCircleNonAlloc)
        int hitCount = Physics2D.OverlapCircle(transform.position, attackRange, enemyContactFilter, hitBuffer);

        if (hitCount == 0)
        {
            return null;
        }

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPos = transform.position;

        for (int i = 0; i < hitCount; i++)
        {
            Collider2D col = hitBuffer[i];
            if (col == null)
            {
                continue;
            }

            Vector3 directionToTarget = col.transform.position - currentPos;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = col.transform;
            }
        }

        return bestTarget;
    }

    private bool IsTargetInRange(Transform target)
    {
        float distanceSqr = (target.position - transform.position).sqrMagnitude;
        return distanceSqr <= (attackRange * attackRange);
    }

    private void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            return;
        }

        Projectile newProjectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        newProjectile.Seek(currentTarget);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        if (currentTarget != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, currentTarget.position);
        }
    }
}