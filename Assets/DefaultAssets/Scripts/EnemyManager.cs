using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // The List to store the points where enemies may spwan
    [SerializeField] private List<GameObject> enemySpawnPoints;
    [SerializeField] private GameObject enemyPrefab;

    int i = 0;

    private void Start()
    {
        if(enemySpawnPoints.Count == 0)
        {
            Debug.Log("Enemies have no active spawn points!");
        }

    }

    private void Update()
    {
        
        if(i < 10)
        {
            i++;
            Debug.Log(i);
            SpawnEnemy();
        }
        
    }

    private void SpawnEnemy()
    {
        int zoneSelector;
        GameObject spawnZone;

        zoneSelector = Random.Range(0, enemySpawnPoints.Count);
        spawnZone = enemySpawnPoints[zoneSelector];

        Instantiate(enemyPrefab, spawnZone.transform);

        //Debug.Log("Spawn in zone: " + zoneSelector);
        //Debug.Log("Zone Name: " + spawnZone);
    }
}
