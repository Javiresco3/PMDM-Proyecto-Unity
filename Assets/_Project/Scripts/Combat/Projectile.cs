using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Configuración de Vuelo")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float hitDistance = 0.15f;
    [SerializeField] private float maxLifetime = 5f;

    [Header("Combate")]
    [SerializeField] private int damage = 1;

    private Transform target;
    private float lifeTimer = 0f;

    public void Seek(Transform newTarget)
    {
        target = newTarget;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        lifeTimer += Time.deltaTime;
        if (lifeTimer >= maxLifetime)
        {
            Destroy(gameObject);
            return;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) <= hitDistance)
        {
            HitTarget();
        }
    }

    private void HitTarget()
    {
        // Cacheo en momento de impacto (evento único, nunca en bucle Update)
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        
        // Comprobación explícita de nulidad sin operador '?.' (cumple con Unity Object)
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}