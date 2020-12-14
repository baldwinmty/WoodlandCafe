using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawning : MonoBehaviour
{
    [Tooltip("The minimum time in seconds until the next spawn.")]
    public float minSpawnTime = 10f;
    [Tooltip("The maximum time in seconds until the next spawn.")]
    public float maxSpawnTime = 25f;
    private float timeUntilSpawn;

    [Tooltip("Prefabs of all the animals who need to spawn in the scene.")]
    public GameObject[] animalPrefabs;

    private void Start()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        // Count down!
        timeUntilSpawn -= Time.deltaTime;

        // When we get to 0...
        if (timeUntilSpawn < 0)
        {
            // Spawn a random animal, then reset the timer!
            Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], gameObject.transform.position, Quaternion.identity);

            timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }
}
