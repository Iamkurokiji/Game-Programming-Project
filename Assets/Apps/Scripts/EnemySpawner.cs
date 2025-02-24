using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public int amountEnemies;
    public float spawnRadius;
    public float minSpawnDistance;
    public float spawnInterval;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemiesRoutine());
        //Starts a coroutine = allows function to run not synchronously overtime rather than
        //executing everything in one frame.
    }

    IEnumerator SpawnEnemiesRoutine()
    {
        while(true)
        {
            SpawnEnemies();
            yield return new WaitforSeconds(spawnInterval);
        }
    }

    void SpawnEnemies()
    {
        for(int i = 0; i < amountEnemies; i++)
        {
            Vector3 spawnPosition = getValidSpawnPosition();
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }

    Vector3 GetValidSpawnPosition()
    {
        Vector3 spawnPosition;
        do
        {
            Vector2 randomCircle = Random.insideUnitCircle.normalized * Random.Range(minSpawnDistance, spawnRadius);
            spawnPosition = new Vector3(randomCircle.x, 0, randomCircle.y) + player.position;
        }
        while (Vector3.Distance(spawnPosition, player.position) < minSpawnDistance);

        return spawnPosition;
    }
}
