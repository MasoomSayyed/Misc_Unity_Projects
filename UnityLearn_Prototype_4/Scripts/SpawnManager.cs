using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject powerupPrefab;
    private float spawnRange = 9f;
    private int enemyCount;
    private int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnWave(waveNumber);
        SpawnPowerUp(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyFollowPlayer>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnWave(waveNumber);
            SpawnPowerUp(waveNumber);
        }
    }

    private Vector3 GetSpawnPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosY = Random.Range(-spawnRange, spawnRange);

        Vector3 spawnPos = new Vector3(spawnPosX, 0, spawnPosY);
        return spawnPos;
    }

    void SpawnWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GetSpawnPos(), enemyPrefab.transform.rotation);
        }
    }
    void SpawnPowerUp(int powerupToSpawn)
    {
        for (int i = 0; i < powerupToSpawn; i++)
        {
            Instantiate(powerupPrefab, GetSpawnPos(), powerupPrefab.transform.rotation);
        }
    }
}
