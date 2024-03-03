using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // The List to store the points where enemies may spwan
    [SerializeField] private List<GameObject> enemySpawnPoints;
    [SerializeField] private GameObject enemyBasePrefab, enemyComplexPrefab;

    [SerializeField] private int totalEnemiesToSpawn;
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
        
        if(i < totalEnemiesToSpawn)
        {
            i++;
            //Debug.Log(i);

            int enemyType = Random.Range(0, 2); // last is exclusive and we want it to be inclusive so we do the max + 1
            //int enemyType = 1;
            
            if(enemyType == 0)
            {
                SpawnEnemy(enemyBasePrefab);
            }
            else if (enemyType == 1)
            {
                SpawnEnemy(enemyComplexPrefab);
            }
            
        }
        
    }

    private void SpawnEnemy(GameObject enemyPrefab)
    {
        int zoneSelector;
        GameObject spawnZone;

        zoneSelector = Random.Range(0, enemySpawnPoints.Count);
        spawnZone = enemySpawnPoints[zoneSelector];

        Instantiate(enemyPrefab, spawnZone.transform.position, spawnZone.transform.rotation);

        //Debug.Log("Spawn in zone: " + zoneSelector);
        //Debug.Log("Zone Name: " + spawnZone);
    }
}
