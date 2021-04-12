using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBGAnimation : MonoBehaviour
{
    public GameObject Player;
    
    Animator animator;
    private PlayerController playercontroller;
    int killHash;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        killHash = Animator.StringToHash("Kill");
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = true;

    }

    // Update is called once per frame
    void Update()
    {
        bool kill = animator.GetBool(killHash);
        if (playercontroller.gameOver == true && !kill)
        {
            float pos = Random.Range(-3, 3);
            Vector3 offset = new Vector3(pos, 0, 0);
            
            transform.position = Player.transform.position + offset;
            
            animator.SetBool(killHash, true);
            audiosource.Play();

        }
    }
}
