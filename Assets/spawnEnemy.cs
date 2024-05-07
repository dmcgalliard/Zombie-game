using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnLocation;
    private float initialSpawnDelay = 5f;
    private int initialEnemyCount = 10;
    private float waveDuration = 120f; 
    private float spawnDelayDecreaseFactor = 0.5f;
    private float spawnRadius = 10f;
    public int waveCount = 6;

    // Start is called before the first frame update.
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }
    

    IEnumerator SpawnEnemies() 
    { 
        int enemyCount = initialEnemyCount;
        float currentSpawnDelay = initialSpawnDelay;
        int currentWave = 1;

        while(currentWave != waveCount + 1) 
        {
            for(int i = 0; i < enemyCount; i++)
            {
                if(enemyPrefab != null) 
                {
                    Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                    Vector3 randomPosition = randomDirection * Random.Range(0, spawnRadius);
                    Vector3 spawnPosition = spawnLocation.position + randomPosition;

                    GameObject enemy = Instantiate(enemyPrefab, spawnPosition, spawnLocation.rotation);
                    CapsuleCollider capsuleCollider = enemy.GetComponent<CapsuleCollider>();
                    capsuleCollider.enabled = true;

                    yield return new WaitForSeconds(currentSpawnDelay);
                }
                else 
                {
                    Debug.LogError("Enemy prefab is null");
                }
            }

            enemyCount = Mathf.RoundToInt(enemyCount + (enemyCount * 0.5f));
            currentSpawnDelay -= spawnDelayDecreaseFactor;
            waveCount++;
            yield return new WaitForSeconds(waveDuration);

        }

        Destroy(gameObject);
        

        
    }

  /*  IEnumerator SpawnEnemies()
    {
   

        int enemyCount = initialEnemyCount;
        float currentSpawnDelay = initialSpawnDelay;
    
        for (int phase = 0; phase < 6; phase++)
        {
            Debug.Log("Phase " + phase + " started");
            for (int i = 0; i < enemyCount; i++)
            {
                Debug.Log("Spawning enemy " + i + " in phase " + phase);
                Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
                Vector3 randomPosition = randomDirection * Random.Range(0, spawnRadius);
                Vector3 spawnPosition = spawnLocation.position + randomPosition;
    
                // Check if enemyPrefab is not null before instantiating
                if (enemyPrefab != null)
                {
                    Instantiate(enemyPrefab, spawnPosition, spawnLocation.rotation);
                    BoxCollider boxCollider = enemyPrefab.GetComponent<BoxCollider>();
                    if(boxCollider != null)
                    {
                        boxCollider.enabled = true;
                    }
                    else 
                    {
                       // Debug.LogError("BoxCollider is null");
                    }
                }
                else
                {
                    // Handle the case where the enemyPrefab is null
                    // You can log an error, instantiate a new enemy, etc.
                  //  Debug.LogError("Enemy prefab is null");
                }
                Debug.Log("Waiting for " + currentSpawnDelay + " seconds before spawning the next enemy");
                yield return new WaitForSeconds(currentSpawnDelay);
                
            }
            Debug.Log("Phase " + phase + " ended");
            Debug.Log("Waiting for " + phaseDuration + " seconds before starting the next phase");
            yield return new WaitForSeconds(phaseDuration);
            currentSpawnDelay -= spawnDelayDecreaseFactor;
            enemyCount = Mathf.RoundToInt(enemyCount + 1); // Increase enemy count by 50%
        }
    
        Destroy(gameObject); // Delete the object after the final phase
        
 
    }
    */
}