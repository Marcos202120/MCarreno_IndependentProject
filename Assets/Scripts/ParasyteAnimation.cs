using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasyteAnimation : MonoBehaviour
{
    Animator animator;
    private PlayerController playercontroller;
    int killHash;
    AudioSource audiosource;
    public AudioClip die;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        killHash = Animator.StringToHash("Kill");
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        bool kill = animator.GetBool(killHash);
        if (playercontroller.gameOver == true && !kill)
        {
            animator.SetBool(killHash, true);
            audiosource.clip = die;
            audiosource.Play();
        }
    }
}