using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Detección y Rango")]
    [SerializeField] private float attackRange = 3f;
    [SerializeField] private LayerMask enemyLayer;

    [Header("Disparo")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate = 1f; // Disparos por segundo

    private float fireCooldown = 0f;
    private Transform currentTarget;
    private readonly Collider2D[] hitBuffer = new Collider2D[10];

    private void Update()
    {
        fireCooldown -= Time.deltaTime;

        // Si no tiene objetivo o el actual se salió del rango, busca uno nuevo
        if (currentTarget == null || !IsTargetInRange(currentTarget))
        {
            currentTarget = FindTarget();
        }

        // Disparo
        if (currentTarget != null && fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = 1f / fireRate;
        }
    }

    private Transform FindTarget()
    {
        // Detección eficiente en memoria sin instanciar listas
        int hitCount = Physics2D.OverlapCircleNonAlloc(transform.position, attackRange, hitBuffer, enemyLayer);

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
    }
}