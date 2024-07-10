using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb; 
    private Animator playerAnim;
    public float horizontalInput;
    public float forwardInput;
    public float speed = 10.0f;
    public float gravityModifier= 1.5f;
    public bool isOnGround = true;
    public float jumpForce = 10;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim= GetComponent<Animator>();
        Physics.gravity *= gravityModifier;  
    }

    void Update()
    {
 horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");  // Cambié "Forward" a "Vertical" para el eje de movimiento correcto

        // Movimiento del jugador
        Vector3 movement = new Vector3(horizontalInput, 0, forwardInput);
        transform.Translate(movement * Time.deltaTime * speed);

        // Verificar si el jugador se está moviendo
        bool isMoving = movement.magnitude > 0;
        playerAnim.SetBool("isMoving", isMoving);
        
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround){
            playerRb.AddForce(Vector3.up*jumpForce, ForceMode.Impulse);
            isOnGround=false;
            playerAnim.SetTrigger("Jumping");
                
            
        }
    }
        private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.CompareTag("Ground")){
            isOnGround= true;
            playerAnim.ResetTrigger("Jumping");
        }
        }
}
