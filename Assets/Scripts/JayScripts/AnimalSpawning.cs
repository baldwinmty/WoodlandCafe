using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawning : MonoBehaviour
{
    [Range(2, 20)]
    public int maxSpawns = 8;

    [HideInInspector]
    public int currentSpawns = 0;

    [Tooltip("The minimum time in seconds until the next spawn.")]
    public float minSpawnTime = 10f;
    [Tooltip("The maximum time in seconds until the next spawn.")]
    public float maxSpawnTime = 25f;
    private float timeUntilSpawn;

    [Tooltip("Prefabs of all the animals who need to spawn in the scene.")]
    public GameObject[] animalPrefabs;

    [Tooltip("Transforms of all the seats in the cafe that the animals can go to.")]
    public Transform[] seats;

    private void Start()
    {
        timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        // Count down!
        timeUntilSpawn -= Time.deltaTime;

        // When we get to 0...
        if (timeUntilSpawn < 0 && currentSpawns < maxSpawns)
        {
            // Spawn a random animal, then reset the timer!
            GameObject animal = Instantiate(animalPrefabs[Random.Range(0, animalPrefabs.Length)], gameObject.transform.position, Quaternion.identity);

            if (animal.TryGetComponent<NPCWalkScript>(out NPCWalkScript animalWalk))
            {
                animalWalk.locations[0] = seats[Random.Range(0, seats.Length)];
                animalWalk.locations[1] = seats[Random.Range(0, seats.Length)];
            }

            timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);
            currentSpawns++;
        }
    }
}
