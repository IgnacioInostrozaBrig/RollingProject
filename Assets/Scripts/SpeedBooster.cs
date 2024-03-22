using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostForce = 500f; // Adjust this value according to your needs

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Assuming your car has the "Player" tag
        {
            Rigidbody carRigidbody = other.GetComponent<Rigidbody>();
            if (carRigidbody != null)
            {
                carRigidbody.AddForce(transform.forward * boostForce, ForceMode.Impulse);
            }
        }
    }
}
