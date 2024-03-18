using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float currentAcceleration;
    public float deceleration;
    public float currentDeceleration;
    public float turnSpeed;
    public float drag;

    private Rigidbody rb;
    public float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float accelerationInput = Input.GetAxis("Vertical");
        currentSpeed = rb.velocity.magnitude;
        currentAcceleration = accelerationInput * acceleration - drag * Mathf.Pow(currentSpeed, 2f);
        currentDeceleration = -accelerationInput * deceleration - drag * Mathf.Pow(currentSpeed, 2f);
        if (accelerationInput != 0f)
        {
            //currentSpeed = Mathf.Clamp(currentSpeed + accelerationInput * acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
            
            rb.AddForce(transform.forward * currentAcceleration, ForceMode.Force);
        }
        else
        {
            
            rb.AddForce(transform.forward * currentDeceleration, ForceMode.Force);
            //currentSpeed = Mathf.Clamp(currentSpeed - decelerationAmount, -maxSpeed, maxSpeed);
        }

        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime * Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
        transform.Rotate(Vector3.up, turn);
    }
}
