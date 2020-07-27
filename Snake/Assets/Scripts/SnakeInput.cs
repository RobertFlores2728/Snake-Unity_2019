using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    //REFERENCE SCRIPTS
    GameManager gmScript;

    //SNAKE DIRECTION
    public Vector2Int snakeDir; //  the direction the user selects to travel in. expressed as a direction vector
    public Vector2Int lastFrameSnakeDir; // direction from last frame. used to prevent snake from going in opposite directions consecutively

    //INPUT DELAY
    float futureTime = 0f; // this time value, meant to hold the value corresponding to a time in the future, is used to determine if enough time has passed. if so, input is accepted
    float inputCooldownDelay = 0.01f; // the time that is added to the current time to create futureTime.

    

    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>(); // references GameManager script
        SetStartSnakeDir();

    }

    // Update is called once per frame
    void Update()
    {
        //if the game is not paused and if the snake has not died, we run the game loop
        if (!gmScript.state.isPaused && !gmScript.state.isDead)
        {
            if (Time.time >= futureTime) // only if we have reached to future time or exceeded it can we take input
                PlayerInput();
            
        }
        
    }

    /**
	* description: handles user input
	*
	* @return: void
	*/
    void PlayerInput() {


        if (Input.anyKeyDown) //if there is key input, reset the input cooldown timer
            futureTime = Time.time + inputCooldownDelay; // this future time value is used to determine if enough time has passed, if so input is accepted

        //does not allow player to go in opposite direction from last frames move
        if (Input.GetKeyDown("w") && lastFrameSnakeDir.y != -1) {
            snakeDir = new Vector2Int(0, 1);
        }
        else if (Input.GetKeyDown("s") && lastFrameSnakeDir.y != 1)
        {
            snakeDir = new Vector2Int(0, -1);
        }

        else if (Input.GetKeyDown("a") && lastFrameSnakeDir.x != 1)
        {
            snakeDir = new Vector2Int(-1, 0);
        }
        else if (Input.GetKeyDown("d") && lastFrameSnakeDir.x != -1)
        {
            snakeDir = new Vector2Int(1, 0);
        }

        
    }


    /**
	* description: sets the starting direction for the snake. snakes goes left at start
	*
	* @return: void
	*/
    void SetStartSnakeDir() {
        snakeDir = new Vector2Int(-1, 0);
        lastFrameSnakeDir = new Vector2Int(0, 1);
    }

    


    


}

