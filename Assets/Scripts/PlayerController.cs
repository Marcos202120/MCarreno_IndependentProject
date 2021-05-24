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

    public GameObject sun;
    public float sunSpawnTime;
    public float nightSpawnTime;
    public float lightIntensity = 1;
    public float multiplier = 10;
    
    public Light playerLantern;
    public float time = 119;
    public bool night = false;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        blood.Stop();
        fog.Stop();
        audiosource = GetComponent<AudioSource>();
        audiosource.playOnAwake = false;

        playerLantern = GameObject.Find("Spot Light").GetComponent<Light>();
        Invoke("LightIntensityIncrease", time);
        sunSpawnTime = Time.time + 60.0f;
        nightSpawnTime = Time.time + 120.0f;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
        
        if (Time.timeSinceLevelLoad > sunSpawnTime)
        {
            night = true;
            sun.SetActive(false);
            sunSpawnTime = Time.timeSinceLevelLoad + 60.0f;
            fog.Play();
            multiplier = 10;
        }
       if(Time.timeSinceLevelLoad > nightSpawnTime)
        {
            night = false;
            sun.SetActive(true);
            nightSpawnTime = Time.timeSinceLevelLoad + 120.0f;
            fog.Stop();
            multiplier = 1;
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
            
            audiosource.clip = dead;
            audiosource.Play();
        }
        if (collision.gameObject.CompareTag("Enemy") && powerPicked)
        {
            enemy = true;
        }
        if(powerPicked == false)
        {
            enemy = false;
            gameManager.powerUpIndicator.SetActive(false);

        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            powerPicked = true;
            Destroy(other.gameObject);
            powerUp.SetActive(true);
            gameManager.powerUpIndicator.SetActive(true);
        }
    }
    void LightIntensityIncrease()
    {
        playerLantern.intensity = lightIntensity * multiplier;
        fog.Play();
    }   

    
}