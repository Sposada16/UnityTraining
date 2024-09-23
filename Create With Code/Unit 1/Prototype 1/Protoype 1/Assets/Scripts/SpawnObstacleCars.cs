using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleCars : MonoBehaviour
{
    public GameObject obstacleCar;
    public Transform spawnPoint;
    private float spawnInterval = 5f;
    public Transform player;
    private float stopDistance = 75f;
    public float startDelay;

    private bool isSpawning = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWithDelay());
    }

    IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(startDelay);

        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while (isSpawning)
        {
            Instantiate(obstacleCar, spawnPoint.position, spawnPoint.rotation);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(spawnPoint.position, player.position);

        Debug.Log("Distance to player: "+distanceToPlayer);

        if(distanceToPlayer <= stopDistance )
        {
            StopSpawning();
        }
    }

    // Update is called once per frame
    public void StopSpawning()
    {
        isSpawning = false;
    }
}
