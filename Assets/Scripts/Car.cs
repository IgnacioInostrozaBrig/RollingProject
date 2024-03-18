using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public float maxSpeed = 20f;
    public float acceleration = 5f;
    public float deceleration = 2f;
    public float turnSpeed = 100f;

    private Rigidbody rb;
    private float currentSpeed = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float accelerationInput = Input.GetAxis("Vertical");
        if (accelerationInput != 0f)
        {
            currentSpeed = Mathf.Clamp(currentSpeed + accelerationInput * acceleration * Time.fixedDeltaTime, -maxSpeed, maxSpeed);
        }
        else
        {
            float decelerationAmount = Mathf.Sign(currentSpeed) * deceleration * Time.fixedDeltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed - decelerationAmount, -maxSpeed, maxSpeed);
        }
        rb.velocity = transform.forward * currentSpeed;
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.fixedDeltaTime * Mathf.Clamp01(rb.velocity.magnitude / maxSpeed);
        transform.Rotate(Vector3.up, turn);
    }
}
