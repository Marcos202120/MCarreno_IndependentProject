using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] Obstacles;
    public float x = 0;
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
        if(playercontroller.gameOver == false)
        {
            int ObstacleIndex = Random.Range(0, Obstacles.Length);
            Vector3 randPos = new Vector3(x, y, z);
            Instantiate(Obstacles[ObstacleIndex], randPos, Obstacles[ObstacleIndex].transform.rotation);
        }
    }
}
