using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    private void Start()
    {
        
    }

    /**
	* description: starts the game
	*
	* @return: void
	*/
    public void PlaySnake() {
        SceneManager.LoadScene("Snake");
    }

    /**
	* description: exits the game, quits the application
	*
	* @return: void
	*/
    public void ExitSnake() {
        //exit the game
        Debug.Log("Quitting");
        Application.Quit();
    }
}
