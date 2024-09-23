using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float spawnCooldown = 1f;
    private float nextSpawnTime = 0f;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog and check if enough time has passed since last spawn
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawnTime)
        {
            // Spawn the dog
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);

            // Set the next allowed spawn time (current time + cooldown)
            nextSpawnTime = Time.time + spawnCooldown;
        }
    }
}
