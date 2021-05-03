using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    Animator animator;
    int isJumpingHash;
    int dieHash;
    int killHash;

    private PlayerController playercontroller;
 
    AudioSource audiosource;
    public AudioClip run;


    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        isJumpingHash = Animator.StringToHash("Isjumping");
        dieHash = Animator.StringToHash("Dead");
        killHash = Animator.StringToHash("Kill");

        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool isjumping = animator.GetBool(isJumpingHash);
        bool dead = animator.GetBool(dieHash);
        bool iskilling = animator.GetBool(killHash);

        if (jump && !isjumping)
        {
            animator.SetBool(isJumpingHash, true);

        }
        if (!jump && isjumping)
        {
            animator.SetBool(isJumpingHash, false);


        }
        if (playercontroller.gameOver == true && !dead)
        {
            animator.SetBool(dieHash, true);
            audiosource.clip = run;
            audiosource.Stop();

        }
        if (playercontroller.powerPicked == true && !iskilling && playercontroller.enemy == true)
        {
            animator.SetBool(killHash, true);
            playercontroller.powerPicked = false;
            playercontroller.powerUp.SetActive(false);
        }
        if (playercontroller.powerPicked == false && iskilling && playercontroller.enemy == false)
        {
            animator.SetBool(killHash, false);
        }
    }
}
