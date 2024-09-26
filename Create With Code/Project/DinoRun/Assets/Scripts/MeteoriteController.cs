using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody meteoriteRb;
    private Vector3 targetPosition;
    public GameObject player;
    public float yOffset = 1.0f;
    public float rotationSpeed = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        meteoriteRb = GetComponent<Rigidbody>();

        // Store the player position when the meteorites spawn
        targetPosition = new Vector3(player.transform.position.x, player.transform.position.y + yOffset, player.transform.position.z);

        // Calculate the direction from the meteorite to the player position
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Set the meteorite velocity to move towards the stored position
        meteoriteRb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(rotationSpeed, rotationSpeed, rotationSpeed) * Time.deltaTime);
    }

    // Detect collisions with the ground
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the meteorite hits the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Meteorite hit the ground!");
            // Destroy the meteorite after the particle effect is triggered
            Destroy(gameObject);
        }
    }
}
