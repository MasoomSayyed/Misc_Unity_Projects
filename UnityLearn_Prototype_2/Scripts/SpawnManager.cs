using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefab;
    private float spawnRangeX = 15;
    private float spawnRangeZ = 15;
    private float startDelay = 2f;
    private float spawnInterval = 1.5f;

    public void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    public void Update()
    {
    }
    public void SpawnRandomAnimal()
    {

        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);
        int animalIndex = Random.Range(0, animalsPrefab.Length);

        Instantiate(animalsPrefab[animalIndex], spawnPos, animalsPrefab[animalIndex].transform.rotation);

    }

}

