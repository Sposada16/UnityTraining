using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 5;
    private float jumpForce = 5; // Force applied for jumping
    private bool isGroudned = true; // Check if the player is on the ground
    private Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move Player Method
        MovePlayer();

        // Jumping logic
        if(Input.GetKeyDown(KeyCode.Space) && isGroudned)
        {
            Jump();
        }
    }

    // Moves the player based on A/D input
    void MovePlayer()
    {
        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");

        playerRb.velocity = new Vector3(horizontalInput * speed, playerRb.velocity.y, playerRb.velocity.z);

    }

    void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
        isGroudned = false;
        Debug.Log("jumping");
    }

    // Trigger detection for obstacles
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Player hit an obstacle!");
        }
        if(other.gameObject.CompareTag("Live"))
        {
            Debug.Log("Player picked up a live!");
            Destroy(other.gameObject);
        }
    }

    // Detect collisions for the player
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player is colliding with the ground
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGroudned = true; 
        }

        //Check if its a collission with a mateorite
        if(collision.gameObject.CompareTag("Meteorite"))
        {
            Debug.Log("Player hit by a meteorite!!");
            Destroy(collision.gameObject);
        }
    }
}
