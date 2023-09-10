using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject gameModifiers;
    public GameObject mainMenu;
    public GameObject settingsMenu;
    
    public GameObject Controller;

    private void Start(){
        if(mainMenu != null){
            gameModifiers.active = false;
            settingsMenu.active = false;
            mainMenu.active = true;
        }
    }
 
    public virtual void LoadGameScene()
    {
        SceneManager.LoadScene("Jeu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu principal");
    }

    public void Continue(){
        Controller.GetComponent<GameControllerScript>().displayMenu();
    }

    public void DisplayGameModifiers(){
        gameModifiers.active = true;
        mainMenu.active = false;
    }

    public void DisplayMenu(){
        gameModifiers.active = false;
        settingsMenu.active = false;
        mainMenu.active = true;
    }
    public void DisplaySettings(){
        settingsMenu.active = true;
        mainMenu.active = false;
    }
}
