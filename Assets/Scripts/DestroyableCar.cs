using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableCar : MonoBehaviour
{
    public Sprite destructionSprite; // Reference to the destruction sprite
    public float destructionDuration = 2f; // Duration of destruction sprite display
    public float minimumCollisionForce = 100f; // Minimum collision force required to destroy the car

    private bool isDestroyed = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isDestroyed && collision.gameObject.CompareTag("Player")) // Assuming the collision is with the player's car and car is not destroyed yet
        {
            // Check collision force magnitude
            if (collision.relativeVelocity.magnitude >= minimumCollisionForce)
            {
                isDestroyed = true; // Mark the car as destroyed

                // Instantiate destruction sprite
                GameObject destruction = new GameObject("DestructionSprite");
                SpriteRenderer spriteRenderer = destruction.AddComponent<SpriteRenderer>();
                spriteRenderer.sprite = destructionSprite;
                destruction.transform.position = transform.position;

                // Destroy the destruction sprite after the specified duration
                Destroy(destruction, destructionDuration);

                // Destroy the car
                Destroy(gameObject);
            }
        }
    }
}
