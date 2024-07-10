using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
   private Rigidbody playerRb;

    public float horizontalInput;
    public float forwardInput;
    private AudioSource audioSource;
    public AudioClip footstepClip; 
    public float speed = 3.0f;
    private Animator playerAnim;
    public float jumpForce = 16;
    public float gravityModifier= 1.5f;
    public bool isOnGround = true;
    public bool isMoving= false;
    private static bool gravityModified= false;
    private static Vector3 originalGravity;
    public GameObject explosionParticle;


    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        if (!gravityModified)
        {
            originalGravity = Physics.gravity;

            Physics.gravity *= gravityModifier;
            gravityModified = true;
        }
                audioSource.clip = footstepClip; // Asigna el clip de audio de pasos
    }
    void OnDisable()
    {
        // Restaurar el valor original de la gravedad
        Physics.gravity = originalGravity;
        gravityModified = false;
    }
    void Update()
    {
       /* horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Forward");
        */
       
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

        if(Input.GetKey(KeyCode.S)){
            transform.Translate(Vector3.back*horizontalInput* Time.deltaTime*speed);
            playerAnim.SetFloat("Speed", -1f);

        }else if(Input.GetKey(KeyCode.W)){
            transform.Translate(Vector3.forward* forwardInput*Time.deltaTime*speed);
            playerAnim.SetFloat("Speed", 1f);

        }else{
            playerAnim.SetFloat("Speed", 0f);
        }
        
            if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetBool("Jumping", true);
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
            // Cargar la escena del menú inicial
            SceneManager.LoadScene("MainMenu");
        }


        if(collision.gameObject.CompareTag("darKnight")){
            if(explosionParticle != null){
            explosionParticle.SetActive(true);
            ParticleSystem ps = explosionParticle.GetComponent<ParticleSystem>();
            if (ps != null)
            {
               ps.Play();
            }
            }    
        }

    }
}
