using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    private float spawnRangeX = 25; // Horizontal range for spawning
    private float spawnRangeZ = 30; // Horizontal range for spawning
    private float spawnPosZ = 20; // Fixed Z position for top spawn
    private float startDelay = 2; // Delay before spawning starts
    private float spawnInterval = 1f; // Time between spawns

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    // Method to spawn a random animal in a random position
    void SpawnRandomAnimal()
    {
        // Choose a random animal prefab
        int animalIndex = Random.Range(0, animalPrefabs.Length);

        // Choose a random side to spawn from (0=Top, 1=Left, 2=Right)
        int spawnSide = Random.Range(0, 3);

        // Spawn rotation of the animal
        Quaternion spawnRotation = animalPrefabs[animalIndex].transform.rotation;

        Vector3 spawnPos = Vector3.zero;

       if(spawnSide == 0) //Top Spawn
       {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
       }
       else if(spawnSide == 1) // Left Spawn
       {
            spawnPos = new Vector3(-spawnRangeX, 0, Random.Range(0, spawnRangeZ));
            spawnRotation = Quaternion.Euler(0, 90, 0);
        }
       else if (spawnSide == 2) // Right Spawn
       {
            spawnPos = new Vector3(spawnRangeX, 0, Random.Range(0, spawnRangeZ));
            spawnRotation = Quaternion.Euler(0, -90, 0);
        }

        Instantiate(animalPrefabs[animalIndex], spawnPos, spawnRotation);
    }
}
