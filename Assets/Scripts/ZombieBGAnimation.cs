using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBGAnimation : MonoBehaviour
{
    public GameObject Player;

    public ParticleSystem fire;
    Animator animator;
    private PlayerController playercontroller;
    int killHash;
    int dieHash;
    public float rate = 20;
    AudioSource audiosource;

    private MoveBack moveBack;

    // Start is called before the first frame update
    void Start()
    {
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        moveBack = GetComponent<MoveBack>();
        animator = GetComponent<Animator>();
        killHash = Animator.StringToHash("Kill");
        dieHash = Animator.StringToHash("Die");
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = true;
        fire.Stop();

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
    private void OnTriggerEnter(Collider other)
    {
        bool dying = animator.GetBool(dieHash);

        if (other.CompareTag("Obstacle") && !dying)
        {
            fire.Play();
            animator.SetBool(dieHash, true);
            moveBack.speed = 2;
        }
    }

}
