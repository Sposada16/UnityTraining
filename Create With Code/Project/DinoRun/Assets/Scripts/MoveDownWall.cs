using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallDown : MonoBehaviour
{
    public float speed = 3.0f;
    public GameObject secondWall;  // Reference to the second wall
    private float wallLength;      // Length of the wall

    private void Start()
    {
        // Calculate the length of the wall using its BoxCollider
        wallLength = GetComponent<BoxCollider>().size.z;
    }

    // Update is called once per frame
    void Update()
    {
        // Move both walls down along the Z-axis
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        secondWall.transform.Translate(Vector3.back * speed * Time.deltaTime);

        // If this wall moves beyond the reset threshold, move it behind the second wall
        if (transform.position.z < -wallLength)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, secondWall.transform.position.z + wallLength);
        }

        // If the second wall moves beyond the reset threshold, move it behind this wall
        if (secondWall.transform.position.z < -wallLength)
        {
            secondWall.transform.position = new Vector3(secondWall.transform.position.x, secondWall.transform.position.y, transform.position.z + wallLength);
        }
    }
}
