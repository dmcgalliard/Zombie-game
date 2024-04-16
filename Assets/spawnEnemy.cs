using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnLocation;
    private float initialSpawnDelay = 5f;
    private int initialEnemyCount = 1;//10;
    private float phaseDuration = 4f; // 180f; // 3 minutes
    private float spawnDelayDecreaseFactor = 0.5f;
    private float spawnRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        int enemyCount = initialEnemyCount;
        float currentSpawnDelay = initialSpawnDelay;

        for (int phase = 0; phase < 6; phase++)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                Vector3 randomPosition = randomDirection * Random.Range(0, spawnRadius);
                Vector3 spawnPosition = spawnLocation.position + randomPosition;

                Instantiate(enemyPrefab, spawnPosition, spawnLocation.rotation);
                yield return new WaitForSeconds(currentSpawnDelay);
                currentSpawnDelay -= spawnDelayDecreaseFactor;
            }

            yield return new WaitForSeconds(phaseDuration);
            enemyCount = Mathf.RoundToInt(enemyCount * 1.5f); // Increase enemy count by 50%
        }

        Destroy(gameObject); // Delete the object after the final phase
    }
}