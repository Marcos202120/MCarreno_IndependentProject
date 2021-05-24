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

    public GameObject[] zombieBG;
    public float bgTime = 3;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        score = 1;
        spawnTime = Time.time + 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(playercontroller.gameOver == false && score < Time.timeSinceLevelLoad)
        {
            score++;
            finalTime.text = "Your time alive was " + score;

        }
        time.text = "Time: " + (int)Time.timeSinceLevelLoad;
        
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
        if (Time.timeSinceLevelLoad > spawnTime)
        {
            StartCoroutine(BGZombieSpawn());
            spawnTime = Time.timeSinceLevelLoad + 5.0f;
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
    IEnumerator BGZombieSpawn()
    {
        yield return new WaitForSeconds(bgTime);
        float x = 3.5f;
        float randZpos = Random.Range(-42, -43);
        float randXPos = Random.Range(-x, x);
        Vector3 randomPos = new Vector3(randXPos, 0, randZpos);
        int zombieBGIndex = Random.Range(0, zombieBG.Length);
        Instantiate(zombieBG[zombieBGIndex], randomPos, zombieBG[zombieBGIndex].transform.rotation);
    }
  
}
