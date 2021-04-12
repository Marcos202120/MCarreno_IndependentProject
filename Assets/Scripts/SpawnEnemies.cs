using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] Obstacles;
    public float xrandPos = 3.5f;
    public float y = 0;
    public float z = 44;
    public float time = 1;
    public float rate = 1.5f;
    private PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", time, rate);
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnRandomEnemy()
    {
        if (playercontroller.gameOver == false)
        {
            float randPos = Random.Range(-xrandPos, xrandPos);
            int ObstacleIndex = Random.Range(0, Obstacles.Length);
            Vector3 randomPos = new Vector3(randPos, y, z);
            Instantiate(Obstacles[ObstacleIndex], randomPos, Obstacles[ObstacleIndex].transform.rotation);
        }
    }
}

