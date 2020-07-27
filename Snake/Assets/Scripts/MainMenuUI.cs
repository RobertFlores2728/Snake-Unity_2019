using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    //REFERENCE SCRIPT
    MainMenuManager mainMenuManagerScript;

    //UI
    GameObject mainMenuGO;
    Button mainMenuPlay;
    Button mainMenuExit;

    // Start is called before the first frame update
    void Start()
    {
        mainMenuManagerScript = GameObject.Find("MainMenuManager").GetComponent<MainMenuManager>();

        InitialiseMainMenu();
    }


    /**
	* description: retreives and initialises the main menu ui objects
	*
	* @return: void
	*/
    void InitialiseMainMenu() {
        mainMenuGO = GameObject.Find("MainMenu");
        mainMenuPlay = mainMenuGO.transform.Find("PlayButton").GetComponent<Button>();
        mainMenuPlay.onClick.AddListener(mainMenuManagerScript.PlaySnake);
        mainMenuExit = mainMenuGO.transform.Find("ExitButton").GetComponent<Button>();
        mainMenuExit.onClick.AddListener(mainMenuManagerScript.ExitSnake);
    }
}
