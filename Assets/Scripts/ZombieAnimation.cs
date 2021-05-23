using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAnimation : MonoBehaviour
{
    public GameObject Player;
    Animator animator;
    private PlayerController playercontroller;
    private GameManager gameManager;
    int killHash;
    int biteHash;
    int dieHash;
    AudioSource audiosource;
    public AudioClip die;
    private BoxCollider cantKill;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        killHash = Animator.StringToHash("Kill");
        biteHash = Animator.StringToHash("Bite");
        dieHash = Animator.StringToHash("Die");
        if(gameManager.paused == false)
        {
            audiosource = GetComponent<AudioSource>();
            audiosource.playOnAwake = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        bool dying = animator.GetBool(dieHash);
        cantKill = FindObjectOfType<BoxCollider>();
        if (collision.gameObject.CompareTag("Player") && playercontroller.powerPicked == true && playercontroller.enemy == true && !dying)
        {
            animator.SetBool(dieHash, true);
            Destroy(cantKill);
        }
        bool kill = animator.GetBool(killHash);

        if (collision.gameObject.CompareTag("Player") && playercontroller.gameOver == true && !kill)
        {           
            
            transform.position = Player.transform.position;
            animator.SetBool(killHash, true);
            audiosource.clip = die;
            audiosource.Play();
            animator.SetBool(biteHash, true);
        }
    }
}
