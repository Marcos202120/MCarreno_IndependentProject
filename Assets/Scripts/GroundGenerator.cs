using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
    public GameObject ground;
    public float time = 1f;
    public float rate = 4f;
    public float x = 0f;
    public float y = 0f;
    public float z = 95f;
    private PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnGround", time, rate);
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnGround()
    {
        if(playercontroller.gameOver == false)
        {
            Vector3 pos = new Vector3(x, y, z);
            Instantiate(ground, pos, ground.transform.rotation);
        }
       
    }
}
