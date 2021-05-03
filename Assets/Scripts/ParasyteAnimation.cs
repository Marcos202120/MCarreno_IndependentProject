using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasyteAnimation : MonoBehaviour
{
    public GameObject Player;
    Animator animator;
    private PlayerController playercontroller;
    int killHash;
    int dieHash;
    AudioSource audiosource;
    public AudioClip die;
    private BoxCollider cantKill;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playercontroller = GameObject.Find("Player").GetComponent<PlayerController>();
        killHash = Animator.StringToHash("Kill");
        dieHash = Animator.StringToHash("Die");
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = false;
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
            audiosource.clip = die;
            audiosource.Play();
           
        }
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

    }
}