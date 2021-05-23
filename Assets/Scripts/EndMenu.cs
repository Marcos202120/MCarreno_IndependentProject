using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void RunButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Zombie Runner");
    }
    public void CreditsButton()
    {
        // Show Credits Menu
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        // Show Main Menu
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
}
