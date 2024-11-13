using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 15.0f;
    private float turnSpeed = 25;
    private float horizontalInput;
    private float verticalInput; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");


        // Move the vehicle forward based on vertical input.
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        //turn the vehicle based on horizontal input
        transform.Rotate(Vector3.up *  Time.deltaTime * speed * horizontalInput);
    }
}
