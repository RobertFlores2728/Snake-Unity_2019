using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    //REFERENCE SCRIPTS
    GameManager gmScript;
    SnakeInput snakeInput;

    //SPAWN SNAKE BODY
    public List<Vector2Int> pastSnakePositions;
    public List<GameObject> snakeTailObjects;
    public int snakeTailSize = 2;

    //USED TO MOVE SNAKE PERIODICALLY
    float moveTimer;
    float moveTimerMax = 0.20f;

    public Vector2Int snakeGridPosition; // tracks the current position of the snake

    int snakeMoveDistance = 1; // the amount of units the snake travels per move. must be at one for this grid based game

    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>(); // references GameManager script
        snakeInput = this.GetComponent<SnakeInput>();
        snakeGridPosition = new Vector2Int(10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gmScript.state.isPaused && !gmScript.state.isDead)
        {
            moveTimer += Time.deltaTime;
            if (moveTimer >= moveTimerMax)
            {
                Move();
                moveTimer = 0f;
            }
        }
    }

    /**
	* description: moves the snake on the grid by
	*
	* @return: void
	*/
    void Move()
    {
        pastSnakePositions.Insert(0, snakeGridPosition); // pre-pends the snake's head position to list of positions
        //deletes any extra positions as we only want positions for the snake to accomodate the number of tail nodes corresponding to snake tail size
        if (pastSnakePositions.Count > snakeTailSize)
        {
            pastSnakePositions.RemoveAt(pastSnakePositions.Count - 1);
        }

        //instantiates a tail object for every position in our list
        while (snakeTailObjects.Count < pastSnakePositions.Count) {
            GameObject snakeTail = Instantiate(GameAssets.instanceGA.snakeTailPrefab, Vector3.zero, Quaternion.identity);
            snakeTailObjects.Insert(0, snakeTail);
        }

        // moves each snake tail object to its current corresponding position
        for (int i = 0; i < pastSnakePositions.Count; i++)
        {
            snakeTailObjects[i].transform.localPosition = new Vector3Int(pastSnakePositions[i].x, pastSnakePositions[i].y, 0);
        }


        snakeGridPosition += snakeInput.snakeDir; // updates snake position variable
        transform.localPosition = new Vector3Int(snakeGridPosition.x * snakeMoveDistance, snakeGridPosition.y * snakeMoveDistance, 0); // applies new position to snake transform
        snakeInput.lastFrameSnakeDir = new Vector2Int(snakeInput.snakeDir.x, snakeInput.snakeDir.y); // updates the current direction, to be used for checking in input on next frame
    }
}
