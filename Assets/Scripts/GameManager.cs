using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI time;
    public TextMeshProUGUI finalTime;

    public GameObject powerUpIndicator;
    public Button restartButton;
    public GameObject ending;
    public GameObject pauseMenu;
    public int score;
    PlayerController playercontroller;
    public bool paused = true;
    public bool hard = false;

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 0;
        
     
    }

    // Update is called once per frame
    void Update()
    {
        
        time.text = "Time: " + score + (int)Time.timeSinceLevelLoad;
        finalTime.text = "Your time alive was " + score + (int)Time.timeSinceLevelLoad;
        if (playercontroller.gameOver == true)
        {
            ending.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
           
            time.gameObject.SetActive(false);
            finalTime.gameObject.SetActive(true);         
        }
        if(paused == false)
        {
            bool pause = Input.GetKeyDown(KeyCode.Escape);
            if (pause)
            {
                paused = true;
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
        }
       
    }
    public void unpauseButton()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void QuitButton()
    {
        // Quit Game
        Application.Quit();
    }
   
}
