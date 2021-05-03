using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public float speed;
    public Vector3 movement = new Vector3(0, 0, -1);
    private PlayerController playercontroller;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playercontroller.gameOver == false)
        {
            transform.Translate(movement * Time.deltaTime * speed);
        }
       

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && playercontroller.powerPicked == true && playercontroller.enemy == true)
        {
            speed = 3;
        }
    }
}
