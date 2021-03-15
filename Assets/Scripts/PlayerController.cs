using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Rate of movement forward and backwards

    public float Tspeed = 20.0f;
    private float horizontalInput;

    public Vector3 jump;
    public float jumpForce = 16.0f;

    public bool isGrounded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * Time.deltaTime * Tspeed * horizontalInput);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


    }

}