using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn2 : MonoBehaviour
{
    public GameObject[] Obstacles;
    private float xPosRange = 4.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", 30f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
    }
    void SpawnRandomAnimal()
    {
        float randXPos = Random.Range(-xPosRange, xPosRange);
        int ObstacleIndex = Random.Range(0, Obstacles.Length);
        Vector3 randPos = new Vector3(randXPos, 0f, 44);
        Instantiate(Obstacles[ObstacleIndex], randPos, Obstacles[ObstacleIndex].transform.rotation);
    }
}
