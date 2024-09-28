using UnityEngine;

public class GroundMover : MonoBehaviour
{
    public float speed = 5.0f; // Speed at which ground moves
    public float tileLength = 10.0f; // Length of each ground tile
    public GameObject player; // Reference to the player

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Move the ground tile backward
        transform.Translate(Vector3.back * speed * Time.deltaTime);

        // Reposition the tile once it has moved beyond the player
        if (transform.position.z < player.transform.position.z - tileLength)
        {
            RepositionTile();
        }
    }

    void RepositionTile()
    {
        // Reposition tile to the front of the player
        transform.position = new Vector3(startPos.x, startPos.y, player.transform.position.z + tileLength * 2);
    }
}
