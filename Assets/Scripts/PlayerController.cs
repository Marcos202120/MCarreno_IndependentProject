using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rate of movement forward and backwards

    public float Tspeed = 20.0f;
    private float horizontalInput;
    public float jumpForce;
    public float gravityModifier;
    public bool isGrounded = true;
    private Rigidbody rbPlayer;
    public bool gameOver = false;


    public ParticleSystem fog;
    public ParticleSystem blood;

    public GameObject powerUp;
    public bool powerPicked = false;
    public bool enemy = false;
    public AudioClip dead;
    AudioSource audiosource;
    
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        blood.Stop();
        fog.Play();
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * Tspeed * horizontalInput);
            bool jump = Input.GetKeyDown(KeyCode.Space);

            if (jump && isGrounded && !gameOver)
            {

                rbPlayer.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
       
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy") && !powerPicked)
        {
            gameOver = true;
            blood.Play();
            fog.Stop();
            audiosource.clip = dead;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy") && powerPicked)
        {
            enemy = true;
        }
        if(powerPicked == false)
        {
            enemy = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            powerPicked = true;
            Destroy(other.gameObject);
            powerUp.SetActive(true);
        }

    }
}