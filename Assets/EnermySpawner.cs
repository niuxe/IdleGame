using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject[] enemyPrefabs;

    [Header("Attributes")]
    [SerializeField]
    private float enermiesPerSecond = 0.1f;

    private bool isSpawning = false;
    private float timeSinceLastSpawn;

    // Start is called before the first frame update
    void Start()
    {
        isSpawning = true;
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSpawning) return;

        timeSinceLastSpawn += Time.deltaTime;

        if(timeSinceLastSpawn >= (1f /enermiesPerSecond))
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0f;
        }
    }

    private void SpawnEnemy()
    {
        GameObject prefabToSpawn = enemyPrefabs[0];
        Instantiate(prefabToSpawn, LevelManager.instance.startingPoint.position, Quaternion.identity);
    }
}
