using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        // Move the car forward/backward
        rb.AddRelativeForce(Vector3.forward * moveInput * speed);

        // Rotate the car left/right
        transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.fixedDeltaTime);
    }
}
