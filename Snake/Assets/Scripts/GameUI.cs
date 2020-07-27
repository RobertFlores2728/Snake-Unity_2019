using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    //REFERENCE SCRIPTS
    GameManager gmScript;

    //SCORE UI
    Text scoreText;
    public int score = 0;

    //PAUSE MENU UI
    GameObject pauseMenuGO;
    Button pauseMenuResume;
    Button pauseMenuQuit;

    //GAMEOVER UI
    GameObject gameOverMenuGO;
    Button gameOverRetry;
    Button gameOverQuit;

    // Start is called before the first frame update
    void Start()
    {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManager>(); // references GameManager script
        
        // add to delegates
        gmScript.snakeScoredDel += IncrementScore;
        gmScript.gameOverDel += DisplayGameOverUI; 
        gmScript.gamePausedDel += DisplayPausedUI;

        InitialiseScore();

        InitialisePauseMenu();
        InitialiseGameOverMenu();


    }


    /**
	* description: sets initial score text
	*
	* @return: void
	*/
    void InitialiseScore() {
        scoreText = GameObject.Find("scoreText").GetComponent<Text>();
        scoreText.text = "0";
    }

    /**
	* description: retreives and initialises the pause menu ui objects
	*
	* @return: void
	*/
    void InitialisePauseMenu() {
        pauseMenuGO = GameObject.Find("PauseMenu");
        pauseMenuResume = pauseMenuGO.transform.Find("ResumeButton").GetComponent<Button>();
        pauseMenuResume.onClick.AddListener(delegate { gmScript.gamePausedDel(); }) ;
        pauseMenuQuit = pauseMenuGO.transform.Find("MainMenuButton").GetComponent<Button>();
        pauseMenuQuit.onClick.AddListener(gmScript.QuitGame);

        pauseMenuGO.SetActive(false);
    }

    /**
	* description: retreives and initialises the game over menu ui objects
	*
	* @return: void
	*/
    void InitialiseGameOverMenu() {
        gameOverMenuGO = GameObject.Find("GameOver");
        gameOverRetry = gameOverMenuGO.transform.Find("GORetryButton").GetComponent<Button>();
        gameOverRetry.onClick.AddListener(gmScript.RestartGame);
        gameOverQuit = gameOverMenuGO.transform.Find("GOMainMenuButton").GetComponent<Button>();
        gameOverQuit.onClick.AddListener(gmScript.QuitGame);

        gameOverMenuGO.SetActive(false);
    }

    /**
	* description: increments the score and text
	*
	* @return: void
	*/
    public void IncrementScore()
    {
        score++;
        Debug.Log(score);
        scoreText.text = "" + score * 100;

    }

    /**
	* description: activates pause menu
	*
	* @return: void
	*/
    public void DisplayPausedUI()
    {
        pauseMenuGO.SetActive(!pauseMenuGO.activeInHierarchy);
    }

    /**
	* description: activates game over menu
	*
	* @return: void
	*/
    public void DisplayGameOverUI()
    {
        gameOverMenuGO.SetActive(!gameOverMenuGO.activeInHierarchy);
    }
}
