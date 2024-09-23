using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    public Slider hungerBar; // Reference to the hunger bar (UI slider)
    private int requiredFood = 3; // The amount of food required to fill the bar
    private int currentFood = 0; // Tracks how much food the animal has received

    // Method to "feed" the animal
    public void FeedAnimal()
    {
        // Increase the current amount of food
        currentFood++;

        // Update the hunger bar
        hungerBar.value = (float)currentFood/requiredFood;

        // Check if animal is fed
        if(currentFood >= requiredFood)
        {
            // The animal is fed, so destroy it
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
