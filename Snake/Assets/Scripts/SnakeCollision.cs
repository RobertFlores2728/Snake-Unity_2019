using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeCollision : MonoBehaviour
{
    //REFERENCE SCRIPTS
    GameManager gmScript;
    SnakeMovement snakeMovement;

    public Vector2Int snakeBounds;

    // Start is called before the first frame update
    void Start()
    {
        snakeBounds = new Vector2Int(12, 12);

        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        snakeMovement = this.GetComponent<SnakeMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gmScript.state.isPaused && !gmScript.state.isDead)
        {
            BoundsCheck();
        }
    }

    /**
	* description: triggered if there snake collides with an object with a collider
	*
	*@param: none
	*
	* @return: void
	*/
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Apple")
        { // colliding with an apple increases score, tail size, and calls to respawn apple
            // place this in game manager
            Debug.Log("Apple Hit");
            Destroy(collision.gameObject);
            gmScript.snakeScoredDel();
            snakeMovement.snakeTailSize++;
        }
        if (collision.gameObject.tag == "SnakeTail") // colliding with tail objects kills the snake, triggers game over
        {
            gmScript.gameOverDel();
        }
    }

    /**
	* description: checks if snake has left the bounds
	*
	*@param: none
	*
	* @return: void
	*/
    void BoundsCheck()
    {
        if (snakeMovement.snakeGridPosition.x > snakeBounds.x || snakeMovement.snakeGridPosition.x < -snakeBounds.x)
        {
            gmScript.gameOverDel(); // kill the snake
        }
        else if (snakeMovement.snakeGridPosition.y > snakeBounds.y || snakeMovement.snakeGridPosition.y < -snakeBounds.y)
        {
            gmScript.gameOverDel();
        }
    }
}
