using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Acceleration and braking
        float accelerationInput = Input.GetAxis("Vertical");
        currentSpeed = Mathf.Clamp(currentSpeed + accelerationInput * acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
        rb.velocity = transform.forward * currentSpeed;

        // Steering
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime * Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
        transform.Rotate(Vector3.up, turn);
    }
}
