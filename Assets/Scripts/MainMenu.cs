using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject menu;
    private PlayerController playerController;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Time.timeScale = 0;
    }

    public void RunButton()
    {
        menu.SetActive(false);
        gameManager.paused = false;
        Time.timeScale = 1;

    }
    public void RunBoyRunButton()
    {
        menu.SetActive(false);
        gameManager.paused = false;
        playerController.jumpForce = 2;
        Time.timeScale = 1;

    }
    public void CreditsButton()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(true);
    }

    public void MainMenuButton()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
