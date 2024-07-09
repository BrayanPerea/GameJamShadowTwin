using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float forwardInput;
    public float speed = 20.0f;

    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right*horizontalInput* Time.deltaTime*speed);
        forwardInput = Input.GetAxis("Forward");
        transform.Translate(Vector3.forward* forwardInput*Time.deltaTime*speed);
    }
}
