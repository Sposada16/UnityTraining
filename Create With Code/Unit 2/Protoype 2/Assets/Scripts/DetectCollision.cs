using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //Find and reference the GameManager in the scene
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When a trigger is detected to the collision method
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            gameManager.DecreaseLives();
        }
        else if(other.CompareTag("Projectile"))
        {
            // If its a projectile, increase the score
            gameManager.IncreaseScore();

            // Feed the animal when hit by a projectile
            AnimalHunger animalHunger = GetComponent<AnimalHunger>();
            if(animalHunger != null)
            {
                animalHunger.FeedAnimal();
            }
            
            Destroy(other.gameObject);
        }
    }
}
