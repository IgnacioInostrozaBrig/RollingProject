using System.Collections;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float currentAcceleration;
    public float deceleration;
    public float currentDeceleration;
    public float turnSpeed;
    public float currentTurnFactor;
    public float drag;
    public float airDrag;
    public float airAngularDrag;
    public float traction;
    public LayerMask groundLayer; // Define the ground layer

    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 movementForce;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = drag;
        rb.angularDrag = 0f;
    }

    void FixedUpdate()
    {
        // Check if the car is grounded using raycasting
        isGrounded = Physics.Raycast(transform.position, -transform.up, 1f, groundLayer);

        float accelerationInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");
        float brakeInput = Input.GetKey(KeyCode.Space) ? 1 : 0;

        // Apply acceleration force if grounded
        if (isGrounded)
        {
            if(brakeInput > 0 && rb.velocity.magnitude > 0.1f)
            {
                movementForce -= rb.velocity.normalized * deceleration * Time.deltaTime;
            }
            else
            {
            }
            movementForce += transform.forward * accelerationInput * acceleration * Time.deltaTime;
            rb.AddForce(movementForce, ForceMode.Force);
            rb.drag = drag;
            rb.angularDrag = 0f;
        }
        else
        {
            rb.drag = airDrag;
            rb.angularDrag = airAngularDrag;
        }

        if (isGrounded)
            {
                if (rb.velocity.magnitude < 10)
            {
                currentTurnFactor = Mathf.Lerp(0f, 1f, Mathf.Abs(rb.velocity.magnitude / 10));
            }
            else
            {
                currentTurnFactor = Mathf.Lerp(1f, 0.5f, Mathf.Abs(rb.velocity.magnitude / maxSpeed));
            }

            // Apply turning force
            float turn = turnInput * turnSpeed * currentTurnFactor * Time.fixedDeltaTime;
            if (accelerationInput < 0)
            {
                turn *= -1;
            }
            transform.Rotate(Vector3.up * turn);
            movementForce *= 1-drag/100;
            movementForce = Vector3.Lerp(movementForce.normalized, transform.forward, traction * Time.deltaTime) * movementForce.magnitude;

        }
        else
        {
            movementForce = new Vector3(rb.velocity.x,0f,rb.velocity.z)*1;
            movementForce = Vector3.Lerp(movementForce.normalized, transform.forward, traction * Time.deltaTime) * movementForce.magnitude;
        }


        // Debug visualization
        Debug.DrawRay(transform.position, transform.forward * 5f, Color.red);
        Debug.DrawRay(transform.position, movementForce.normalized * 5f, Color.green);
    }
}
