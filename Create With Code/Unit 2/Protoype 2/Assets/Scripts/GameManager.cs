using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int playerLives = 3; // Player will start with 3 lives
    public int playerScore = 0; // Player Starts with 0 score

    // Start is called before the first frame update
    void Start()
    {
        //Display initial lives and score in the console
        Debug.Log("Lives = " +  playerLives);
        Debug.Log("Score = " + playerScore);
    }

    // Method to increase score when player hits an animal
    public void IncreaseScore()
    {
        playerScore++;
        Debug.Log("Score = " + playerScore);
    }

    //Method to decrease lives when the player misses or is hit
    public void DecreaseLives()
    {
        playerLives--;

        if(playerLives > 0)
        {
            Debug.Log("Lives = " + playerLives);
        }
        else
        {
            Debug.Log("Game over, no more lives");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
