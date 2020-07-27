using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public delegate void SnakeScored();
    public SnakeScored snakeScoredDel;

    public delegate void GameOver();
    public GameOver gameOverDel;

    public delegate void GamePause();
    public GamePause gamePausedDel;


    //REFERENCE SCRIPTS
    GameUI g_uiScript;



    //GAME STATE
    public struct gameState {
        public bool isPaused;
        public bool isDead;
    }
    public gameState state;

    // Start is called before the first frame update
    void Start()
    {
        snakeScoredDel += SpawnApple;
        gameOverDel += KillSnake;
        gamePausedDel += PauseGame;

        InitialiseGameState();

        SpawnApple();
        SpawnSnake();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("p"))
            gamePausedDel();
    }


    /**
	* description: initialises the game state struct with the right settings
	*
	* @return: void
	*/
    void InitialiseGameState() {
        state = new gameState();
        state.isPaused = false;
        state.isDead = false;
    }

    /**
	* description: spawns a new apple randomly within bounds
	*
	* @return: void
	*/
    public void SpawnApple() {
        GameObject newApple = Instantiate(GameAssets.instanceGA.applePrefab, Vector3.zero, Quaternion.identity);
        newApple.transform.localPosition = new Vector3Int(Random.Range(-12, 12), Random.Range(-12, 12), 0);
    }

    /**
	* description: spawns a new player snake. only done once per game
	*
	* @return: void
	*/
    public void SpawnSnake()
    {
        GameObject newSnake = Instantiate(GameAssets.instanceGA.snakePrefab, Vector3.zero, Quaternion.identity);
        newSnake.transform.localPosition = new Vector3Int(0, Random.Range(-10, 10), 0);
    }

    /**
	* description: sets the state to the opposite of what it is now
	*
	* @return: void
	*/
    public void PauseGame() {
        state.isPaused = !state.isPaused;
    }

    /**
	* description: sets game state to dead
	*
	* @return: void
	*/
    public void KillSnake()
    {
        state.isDead = true;
    }

    /**
	* description: loads the main menu scene
	*
	* @return: void
	*/
    public void QuitGame() {
        // change scene to main scene
        SceneManager.LoadScene("MainMenu");
    }


    /**
	* description: loads the current game scene
	*
	* @return: void
	*/
    public void RestartGame() {
        SceneManager.LoadScene("Snake");
    }

   

    

}
