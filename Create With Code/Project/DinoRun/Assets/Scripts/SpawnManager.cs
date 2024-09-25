using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] dinoPrefabs; // Array of dino prefabs
    public GameObject[] treePrefabs; // Array of tree prefabs
    public GameObject livePrefab; // Live prefab
    public GameObject meteoritePrefab; // Meteorite prefab

    public float spawnRangeX = 5.0f; // X range for random Spawning
    public float meteoriteSpawnRangeYmin = 6.0f; // min Y position for spawning above ground
    public float meteoriteSpawnRangeYmax = 10.0f; // max Y position for spawning above ground

    private float dinoAndTreeSpawnInterval = 2.0f; // Time between spawning dinos and trees
    private float lifeSpawnInterval = 15.0f; // Time between spawning lives
    private float meteoriteSpawnInterval = 3.0f; // Fixed time for meteorite spawn

    void Start()
    {
        // Start spawning dinos and trees
        StartCoroutine(SpawnDinosAndTrees());

        // Start spawning lives occasionally
        StartCoroutine(SpawnLivesOccasionally());

        // Start spawning meteorites every 3 seconds
        InvokeRepeating("SpawnMeteorite", 2.0f, meteoriteSpawnInterval);
    }

    // Coroutine to spawn dinos and trees often
    IEnumerator SpawnDinosAndTrees()
    {
        while (true)
        {
            // Random X position for spawning
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);

            // Randomly choose a dino prefab from the array
            int randomDinoIndex = Random.Range(0, dinoPrefabs.Length);
            GameObject dinoPrefab = dinoPrefabs[randomDinoIndex];

            // Spawn a dino with adjusted Y position based on its collider
            Vector3 dinoSpawnPos = new Vector3(randomX, 0, 20);
            SpawnGroundedObject(dinoPrefab, dinoSpawnPos);

            // Delay before spawning the tree to avoid overlap
            yield return new WaitForSeconds(1.0f);

            // Random X position for tree (you can choose to use the same randomX or a new one)
            randomX = Random.Range(-spawnRangeX, spawnRangeX);

            // Randomly choose a tree prefab from the array
            int randomTreeIndex = Random.Range(0, treePrefabs.Length);
            GameObject treePrefab = treePrefabs[randomTreeIndex];

            // Spawn a tree with adjusted Y position based on its collider
            Vector3 treeSpawnPos = new Vector3(randomX, 0, 20);
            SpawnGroundedObject(treePrefab, treeSpawnPos);

            // Wait for the next spawn cycle
            yield return new WaitForSeconds(dinoAndTreeSpawnInterval - 1.0f); // Subtracting 1 sec since we already waited for the tree
        }
    }

    // Coroutine to spawn lives occasionally
    IEnumerator SpawnLivesOccasionally()
    {
        // Add an initial delay before the first life spawns
        yield return new WaitForSeconds(lifeSpawnInterval);

        while (true)
        {
            // Random X position for life
            float randomX = Random.Range(-spawnRangeX, spawnRangeX);

            // Spawn a life object with adjusted Y position based on its collider
            Vector3 lifeSpawnPos = new Vector3(randomX, 0, 20);
            SpawnGroundedObject(livePrefab, lifeSpawnPos);

            // Wait for the next life spawn
            yield return new WaitForSeconds(lifeSpawnInterval);
        }
    }

    // Method to spawn meteorites at a fixed interval
    void SpawnMeteorite()
    {
        // Random X position for meteorite
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);

        // Random Y position for meteorite
        float randomY = Random.Range(meteoriteSpawnRangeYmin, meteoriteSpawnRangeYmax);

        // Spawn a meteorite
        Vector3 meteoriteSpawnPos = new Vector3(randomX, randomY, 20);
        Instantiate(meteoritePrefab, meteoriteSpawnPos, meteoritePrefab.transform.rotation);
    }

    // Helper method to spawn objects and adjust their Y position based on their collider
    void SpawnGroundedObject(GameObject prefab, Vector3 spawnPosition)
    {
        GameObject spawnedObject = Instantiate(prefab, spawnPosition, prefab.transform.rotation);

        // Adjust the Y position to place the bottom of the collider at ground level
        Collider objectCollider = spawnedObject.GetComponent<Collider>();
        if (objectCollider != null)
        {
            // Get the distance from the center of the object to the bottom of its collider
            float objectHeight = objectCollider.bounds.extents.y;
            spawnedObject.transform.position = new Vector3(spawnPosition.x, objectHeight, spawnPosition.z);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
