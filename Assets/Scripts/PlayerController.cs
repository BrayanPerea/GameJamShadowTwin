using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float horizontalInput;
    public float invertedInput;
    public float forwardInput;
    public float speed = 10.0f;
    public float jumpForce = 10;
    public float gravityModifier;
    private bool isOnGround= true;
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
        if(gameObject.CompareTag("PlayerSoul")){
            invertedInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.left*invertedInput* Time.deltaTime*speed);
        }else{
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*horizontalInput* Time.deltaTime*speed);
        }
        forwardInput = Input.GetAxis("Forward");
        transform.Translate(Vector3.forward* forwardInput*Time.deltaTime*speed);

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isOnGround=false;
        }
    }

     private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")){
                    isOnGround= true;
        }
     }
}
