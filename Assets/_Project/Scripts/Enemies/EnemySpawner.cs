using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Referencias")]
    [SerializeField] private EnemyMovement enemyPrefab;
    [SerializeField] private WaypointPath targetPath;

    [Header("Configuración de Oleada")]
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private int totalEnemiesToSpawn = 5;

    private int spawnedCount = 0;
    private float timer = 0f;

    private void Start()
    {
        if (enemyPrefab == null)
        {
            Debug.LogError($"[EnemySpawner] No hay prefab de enemigo asignado en {gameObject.name}.", this);
            enabled = false;
            return;
        }

        if (targetPath == null)
        {
            Debug.LogError($"[EnemySpawner] No hay WaypointPath asignado en {gameObject.name}.", this);
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        if (spawnedCount >= totalEnemiesToSpawn)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        // Instancia directamente la referencia tipada sin hacer GetComponent()
        EnemyMovement newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        newEnemy.SetPath(targetPath);
        
        spawnedCount++;
    }
}