using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayerController : MonoBehaviour
{
    Animator animator;
    int isJumpingHash;
    int dieHash;
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
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = false;

    }

    // Update is called once per frame
    void Update()
    {
        bool jump = Input.GetKeyDown(KeyCode.Space);
        bool isjumping = animator.GetBool(isJumpingHash);
        bool dead = animator.GetBool(dieHash);
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
    }
}
