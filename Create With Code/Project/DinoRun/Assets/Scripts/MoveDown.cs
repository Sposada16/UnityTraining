using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 3.0f;
    private Rigidbody objectRb;
    public float zDestroy = -10f;

    // Start is called before the first frame update
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();

        // Set initial velocity
        objectRb.velocity = Vector3.back * speed;
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy the object if it moves past the Z Destroy position
        if (transform.position.z < zDestroy)
        {
            if(transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            
        }
    }
}