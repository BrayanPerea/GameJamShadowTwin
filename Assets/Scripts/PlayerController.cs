using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private static Vector3 originalGravity;
    private AudioSource audioSource;

    public float horizontalInput;
    public float forwardInput;
    public float speed = 5.0f;
    public float jumpForce = 10.0f;
    public bool isOnGround;
    public bool isMoving = false;
    public AudioClip footstepClip;
    public float downForce = 22f;

        void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = footstepClip;
    }

    void Update()
    {
        HandleMovement();
        HandleJumping();
        HandleFootsteps();
    }
    

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * horizontalInput * Time.deltaTime * speed);
            playerAnim.SetFloat("Speed", -1f);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * forwardInput * Time.deltaTime * speed);
            playerAnim.SetFloat("Speed", 1f);
        }
        else
        {
            playerAnim.SetFloat("Speed", 0f);
        }
    }

    private void HandleJumping()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetBool("Jumping", true);
            }

        if (!isOnGround)
        {
            playerRb.AddForce(Vector3.down * downForce);
        }
    }

    private void HandleFootsteps()
    {
        if (isOnGround && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.W)))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            playerAnim.SetBool("Jumping", false);
        }

        if (collision.gameObject.CompareTag("GameOver"))
        {
            SceneManager.LoadScene("GameOver");
        }
        if(collision.gameObject.CompareTag("darKnight")){
            SceneManager.LoadScene("WinLevel");
            }
    }
}
